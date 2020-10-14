using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class User
    {
        #region Model
        public User() { }
        private string _username;
        private string _password;
        private string _miaoshu;
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
        public string Password 
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string miaoshu 
        {
            set { _miaoshu = value; }
            get { return _miaoshu; }
        }
        #endregion Model
    }
}
