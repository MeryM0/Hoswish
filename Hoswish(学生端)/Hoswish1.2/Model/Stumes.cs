using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class Stumes
    {
        public Stumes() { }
        #region Model
        private string _name;
        private string _number;
        private string _major;
        private string _stuclass;
        private string _pic;
        /// <summary>
        /// 学生名字
        /// </summary>
        public string Name 
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 学生学号
        /// </summary>
        public string Number 
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 学生专业
        /// </summary>
        public string Major
        {
            set { _major = value; }
            get { return _major; }
        }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string Stuclass
        {
            set { _stuclass = value; }
            get { return _stuclass; }
        }
        /// <summary>
        /// 学生头像
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }

        #endregion Model
    }
}
