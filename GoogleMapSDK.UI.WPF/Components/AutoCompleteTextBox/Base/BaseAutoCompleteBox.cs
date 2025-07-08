using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GoogleMapSDK.Contract.ComponentContract;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.UI.WPF.Component.Enum;
using GoogleMapSDK.UI.WPF.Utility;
using Newtonsoft.Json.Linq;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;

namespace GoogleMapSDK.UI.WPF.Components.AutoCompleteTextBox.Base
{
    public abstract class BaseAutoCompleteBox<T1, T2> : UserControl, AutoCompleteTextBoxBase
    {
        // 建構元
        public BaseAutoCompleteBox() { Initialize(); }
        private AutoTextBoxState state;
        private string _displayMember;
        protected TextBox _textBox;
        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }
            set
            {
                this._displayMember = value;
            }
        }
        private string _valueMember;
        public string ValueMember
        {
            get
            {
                return _valueMember;
            }
            set
            {
                this._valueMember = value;

            }
        }
        public BasePresenter Presenter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        protected ListBox _listBox;
        public abstract Action<object, Place> PlaceSelected { get; set; }

        private IEnumerable<T1> _dataSource;
        public IEnumerable<T1> DataSource
        {
            get
            {
                return this._dataSource;
            }
            set
            {
                this._dataSource = value;
                UpdateListBox();
            }
        }
        public EventHandler<T2> SelectedValueChanged;
        public EventHandler<int> SelectedIndexChanged;
        public EventHandler<T2> SelectFinished;

        protected abstract void GetCompleteSource();
        protected abstract T2 GetSelectItem(T1 selectedItem);

        private Func<T1, string> GetDisplayFunc = null;
        private Func<T1, T2> GetValueFunc = null;

        private string GetDisplayName(T1 item)
        {
            if (GetDisplayFunc != null) return GetDisplayFunc(item);
            try
            {
                Type itemType = DataSource.GetType().GetGenericArguments()[0];
                if (itemType == null)
                {

                }
                var displayInfo = itemType.GetProperty(DisplayMember);
                if (displayInfo == null)
                {
                    throw new Exception($"Cannot find the property named '{DisplayMember}'");
                }
                GetDisplayFunc = (x) => displayInfo.GetValue(x).ToString();
                return GetDisplayFunc(item);


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private T2 GetValue(T1 item)
        {
            if (GetValueFunc != null) return GetValueFunc.Invoke(item);

            Type itemType = DataSource.GetType().GetGenericArguments()[0];
            var displayInfo = itemType.GetProperty(_valueMember);
            if (displayInfo == null)
            {
                throw new Exception($"Cannot find the property named '{_valueMember}'");
            }
            GetValueFunc = (x) => (T2)displayInfo.GetValue(x);
            return GetValueFunc.Invoke(item);
        }
        public abstract void AutoCompleteFinish<T>(List<T> queries);

        public abstract void GetPlactDetailFinish<T>(T place);

        public void Initialize()
        {
            _listBox = new ListBox();
            _textBox = new TextBox();
            this.KeyUp += OnKeyUp;
            this._textBox.TextChanged += OnTextChanged;
            Grid mainLayoutGrid = new Grid();
            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto; // 第一行自動調整高度 (用於 TextBox)
            mainLayoutGrid.RowDefinitions.Add(row1);

            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(1, GridUnitType.Star); // 第二行佔據剩餘空間 (用於 ListBox)
            mainLayoutGrid.RowDefinitions.Add(row2);
            Grid.SetRow(_textBox, 0); // TextBox 放在第一行
            mainLayoutGrid.Children.Add(_textBox);

            Grid.SetRow(_listBox, 1); // ListBox 放在第二行
            mainLayoutGrid.Children.Add(_listBox);

            // 5. 將這個 Grid 設定為 UserControl 的唯一內容
            this.Content = mainLayoutGrid;
            _listBox.Visibility = Visibility.Collapsed;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.state == AutoTextBoxState.Preview) return;
            GetCompleteSource();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            WPFKeyConverter.TryConvert(e.Key, out ConsoleKey key );
            this_KeyUp(sender, key);
        }



        public void this_KeyUp(object sender, ConsoleKey e)
        {


            // keyup不斷監聽使用者輸入，在debouncetime 結束後，將輸入的字串內容發送給使用者(使用者必須監聽keyup事件)
            // 使用者根據收到的字串結果，進行api發送，將api response 結果傳入 DataSource
            // DataSource 收到之後進行畫面渲染
            UpdateListBox();
            switch (e)
            {
                case ConsoleKey.Tab:
                    if (_listBox.Visibility == System.Windows.Visibility.Hidden) return;
                    //e.SuppressKeyPress = true;
                    state = AutoTextBoxState.Complete;
                    this._textBox.Text = (string)GetDisplayName((T1)_listBox.SelectedItem);
                    this._textBox.SelectionStart = this._textBox.Text.Length;
                    _listBox.Visibility = System.Windows.Visibility.Hidden;
                    var item = GetSelectItem((T1)_listBox.SelectedItem);
                    this.SelectFinished?.Invoke(this, item);
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (_listBox.Visibility == System.Windows.Visibility.Hidden) return;
                        _listBox.SelectedIndex =
                            _listBox.SelectedIndex < _listBox.Items.Count - 1 ?
                            _listBox.SelectedIndex + 1 :
                            0;
                        state = AutoTextBoxState.Preview;
                        this._textBox.Text = (string)GetDisplayName((T1)_listBox.SelectedItem);
                        this._textBox.SelectionStart = this._textBox.Text.Length;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if (_listBox.Visibility == System.Windows.Visibility.Hidden) return;
                        _listBox.SelectedIndex =
                            _listBox.SelectedIndex > 0 ?
                            _listBox.SelectedIndex - 1 :
                            _listBox.Items.Count - 1;
                        this._textBox.Text = (string)GetDisplayName((T1)_listBox.SelectedItem); ;
                        this._textBox.SelectionStart = this._textBox.Text.Length;
                        break;
                    }

                case ConsoleKey.Backspace:
                    {
                        state = AutoTextBoxState.Editing;
                        break;
                    }
            }
        }
    


        public void UpdateListBox()
        {
            if (state != AutoTextBoxState.Editing) return;

            if (DataSource == null) return;
            string inputText = this._textBox.Text;


            if (inputText.Length < 1)
            {
                _listBox.Visibility = System.Windows.Visibility.Collapsed;
                return;
            }
            if (DataSource == null) return;

            var matches = new List<object>();
            foreach (var item in DataSource)
            {
                if (GetDisplayName(item).ToString().ToLower().Contains(inputText.ToLower()))
                { matches.Add(item); }
            }

            if (matches.Count == 0)
            {
                _listBox.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            _listBox.Visibility = System.Windows.Visibility.Visible;
            _listBox.ItemsSource = matches;
            
            _listBox.DisplayMemberPath = DisplayMember;
            
            _listBox.SelectedIndex = 0;

            _listBox.FontFamily = new System.Windows.Media.FontFamily("微軟正黑體");

            //int itemheghit = TextRenderer.MeasureText("測試", _listBox.Font).Height + 5;
            int itemheghit = 15;
            _listBox.Height = itemheghit * matches.Count;
            _listBox.Width = this.Width;
        }
    }
}
