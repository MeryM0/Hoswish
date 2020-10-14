using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class Hos
    {
        public Hos(){}

        #region Model
        private int _hos_id;
        private string _hos_name;
        private string _hos_detail;
        private int _hos_how;
        private string _hos_title;
        /// <summary>
        /// 医院id
        /// </summary>
        public int Hos_id
        {
            set { _hos_id = value; }
            get { return _hos_id; }
        }
        /// <summary>
        /// 医院详细信息
        /// </summary>
        public string Hos_detail
        {
            set { _hos_detail = value; }
            get { return _hos_detail; }
        }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string Hos_Name
        {
            set { _hos_name = value; }
            get { return _hos_name; }
        }
        /// <summary>
        /// 医院招收人数
        /// </summary>
        public int Hos_how
        {
            set { _hos_how = value; }
            get { return _hos_how; }
        }
        /// <summary>
        /// 医院标题
        /// </summary>
        public string Hos_title
        {
            set { _hos_title = value; }
            get { return _hos_title; }
        }
        #endregion Model
    }
}
