using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class wish
    {
        public wish(){}
        #region Model
        private string _first;
        private string _second;
        private string _third;
        private string _username;
        private string _result;
        /// <summary>
        /// 第一志愿
        /// </summary>
        public string First
        {
            set { _first = value; }
            get { return _first; }
        }
        /// <summary>
        /// 第二志愿
        /// </summary>
        public string Second
        {
            set { _second = value; }
            get { return _second; }
        }
        /// <summary>
        /// 第三志愿
        /// </summary>
        public string Third
        {
            set { _third = value; }
            get { return _third; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        public string Result 
        {
            set { _result = value; }
            get { return _result; }
        }
        #endregion Model
    }
}
