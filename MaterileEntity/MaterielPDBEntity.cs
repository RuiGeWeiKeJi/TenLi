using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MaterileEntity
{
    public class MaterielPDBEntity
    {
        private string _pdb001;
        private string _pdb002;
        private string _pdb003;
        private DateTime? _pdb004;
        private byte [] _pdb005;

        /// <summary>
        /// 合同号
        /// </summary>
        public string PDB001
        {
            get
            {
                return _pdb001;
            }

            set
            {
                _pdb001 = value;
            }
        }

        /// <summary>
        /// 附件名称
        /// </summary>
        public string PDB002
        {
            get
            {
                return _pdb002;
            }

            set
            {
                _pdb002 = value;
            }
        }

        /// <summary>
        /// 附件类型
        /// </summary>
        public string PDB003
        {
            get
            {
                return _pdb003;
            }

            set
            {
                _pdb003 = value;
            }
        }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? PDB004
        {
            get
            {
                return _pdb004;
            }

            set
            {
                _pdb004 = value;
            }
        }

        /// <summary>
        /// 附件
        /// </summary>
        public byte [ ] PDB005
        {
            get
            {
                return _pdb005;
            }

            set
            {
                _pdb005 = value;
            }
        }
    }
}
