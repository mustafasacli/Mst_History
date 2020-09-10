using System;

namespace Mst.DBObjects
{
    public class Param
    {

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_Name))
                    throw new Exception("Parameter Name can not be null or empty.");
                else
                    return _Name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new Exception("Parameter Name can not be null or empty.");
                else
                    _Name = value;
            }
        }

        public object Value
        { get; set; }
    }
}
