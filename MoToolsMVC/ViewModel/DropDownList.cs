using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.ViewModel
{
    public class DropDownList
    {
        #region Properties

        public IEnumerable<SelectListItem> Options { get; }

        private SelectListItem _selectedOption;
        public SelectListItem SelectedOption { get { return _selectedOption; } }

        #endregion

        #region Constructor

        public DropDownList(List<DropDownOption> options, bool hasEmptyOption = false, string selectedOptionValue = null)
        {
            if (hasEmptyOption)
            {
                options.Add(new DropDownOption("", ""));
            }
            this.Options = new SelectList(options, "Value", "Text");
            if (!String.IsNullOrEmpty(selectedOptionValue))
            {
                this._selectedOption = this.Options.FirstOrDefault(o => o.Value == selectedOptionValue);
            }
        }

        #endregion

        #region Public Setters

        public void SetSelectedOptionByText(string text)
        {
            this._selectedOption = this.Options.FirstOrDefault(o => o.Text == text);
        }

        public void SetSelectedOptionByValue(string value)
        {
            this._selectedOption = this.Options.FirstOrDefault(o => o.Value == value);
        }

        #endregion
    }
}