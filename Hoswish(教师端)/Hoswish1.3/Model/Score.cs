using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class Score
    {
        public Score() { }
        #region Model

        private string _username;
        private string _formula;
        private string _endresult;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Formula
        {
            set { _formula = value; }
            get { return _formula; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Endresult
        {
            set { _endresult = value; }
            get { return _endresult; }
        }
        #endregion Model
    }
}
