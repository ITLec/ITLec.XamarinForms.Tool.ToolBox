namespace ITLec.XamarinForms.Tool.AutoCompleteLookup
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AutoCompleteListItem
    {
        public string DisplayText
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}