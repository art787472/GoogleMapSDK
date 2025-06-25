using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Core.Component.Enum;
using System.Drawing;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using GoogleMapSDK.Contract.Models;

namespace GoogleMapSDK.UI.Winform.Components.BaseAutoCompleteTextBox
{
    public abstract class BaseAutoCompleteBox<T1, T2> : TextBox, AutoCompleteTextBoxBase
    {
        public AutoTextBoxState state = AutoTextBoxState.Editing;
        private string _displayMember;
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
        protected ListBox _listBox;
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


        private Func<T1, string> GetDisplayFunc = null;
        private Func<T1, T2> GetValueFunc = null;

        protected abstract void GetCompleteSource();
        protected abstract T2 GetSelectItem(T1 selectedItem);

        public int SelectedIndex
        {
            get
            {
                return _listBox.SelectedIndex;
            }
            set
            {
                _listBox.SelectedIndex = value;
            }
        }

        public BasePresenter Presenter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public abstract Action<object, Place> PlaceSelected { get ; set ; }

        public BaseAutoCompleteBox()
        {
            Initialize();
        }

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

        public void Initialize()
        {
            _listBox = new ListBox();
            KeyUp += this_KeyUp;
            TextChanged += AutoCompleteTextBox_TextChanged;
            ParentChanged += MyAutoCompleteTextBox_ParentChanged;
            _listBox.Click += _listBox_Click;
            _listBox.SelectedIndexChanged += _listBox_SelectedIndexChanged;
            _listBox.SelectedValueChanged += _listBox_SelectedValueChanged;
        }

        private void AutoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (state == AutoTextBoxState.Preview) return;
            GetCompleteSource();


        }

        private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                this.SelectedIndexChanged?.Invoke(this, SelectedIndex);
        }

        private void _listBox_SelectedValueChanged(object sender, EventArgs e)
        {
                this.SelectedValueChanged?.Invoke(this, GetValue((T1)_listBox.SelectedItem));
        }

        private void _listBox_Click(object sender, EventArgs e)
        {
            var item = sender;
            this.Text = (string)GetDisplayName((T1)_listBox.SelectedItem);
            SelectionStart = Text.Length;
            this._listBox.Visible = false;
            
            this.SelectFinished?.Invoke(this, GetSelectItem((T1)_listBox.SelectedItem));
            state = AutoTextBoxState.Complete;
        }

        private void MyAutoCompleteTextBox_ParentChanged(object sender, EventArgs e)
        {
            _listBox.Left = Left;
            _listBox.Top = Top + Height;
            _listBox.Visible = false;
            Parent.Controls.Add(_listBox);
        }

        public void this_KeyUp(object sender, KeyEventArgs e)
       {

            // keyup不斷監聽使用者輸入，在debouncetime 結束後，將輸入的字串內容發送給使用者(使用者必須監聽keyup事件)
            // 使用者根據收到的字串結果，進行api發送，將api response 結果傳入 DataSource
            // DataSource 收到之後進行畫面渲染
            UpdateListBox();
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (!_listBox.Visible) return;
                    e.SuppressKeyPress = true;
                    state = AutoTextBoxState.Complete;
                    this.Text = (string)GetDisplayName((T1)_listBox.SelectedItem);
                    SelectionStart = Text.Length;
                    _listBox.Visible = false;
                    var item = GetSelectItem((T1)_listBox.SelectedItem);
                    this.SelectFinished?.Invoke(this, item);
                    break;

                case Keys.Down:
                    {
                        if (!_listBox.Visible) return;
                        _listBox.SelectedIndex =
                            _listBox.SelectedIndex < _listBox.Items.Count - 1 ?
                            _listBox.SelectedIndex + 1 :
                            0;
                        state = AutoTextBoxState.Preview;
                        this.Text = (string)GetDisplayName((T1)_listBox.SelectedItem);
                        SelectionStart = Text.Length;
                        break;
                    }
                case Keys.Up:
                    {
                        if (!_listBox.Visible) return;
                        _listBox.SelectedIndex =
                            _listBox.SelectedIndex > 0 ?
                            _listBox.SelectedIndex - 1 :
                            _listBox.Items.Count - 1;
                        this.Text = (string)GetDisplayName((T1)_listBox.SelectedItem); ;
                        SelectionStart = Text.Length;
                        break;
                    }

                case Keys.Back:
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
            string inputText = this.Text;


            if (inputText.Length < 1)
            {
                _listBox.Visible = false;
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
                _listBox.Visible = false;
                return;
            }

            _listBox.Visible = true;

            _listBox.DataSource = matches;
            _listBox.DisplayMember = DisplayMember;
            _listBox.SelectedIndex = 0;

            _listBox.Font = new Font("微軟正黑體", 16);
            int itemheghit = TextRenderer.MeasureText("測試", _listBox.Font).Height + 5;
            _listBox.Height = itemheghit * matches.Count;
            _listBox.Width = this.Width;

        }

        public abstract void AutoCompleteFinish<T>(List<T> queries);

        public abstract void GetPlactDetailFinish<T>(T place);
    }
}
