using GitUtility.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormCloneRepo : Form
    {
        public FormCloneRepo()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
        }
    }
}
