using System;
using System.Collections;
using System.Windows.Forms;
namespace KeywordManagement.Domain
{
    internal class TreeContentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((TreeNode)x).Text.CompareTo(((TreeNode)y).Text);
        }
    }
}
