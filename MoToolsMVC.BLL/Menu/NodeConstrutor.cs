using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoToolsMVC.BLL.Menu
{
    public abstract class Node
    {
        #region fields
        protected string _nodeHtml;
        protected string _menuName;
        protected string _menuUrl;
        protected string _closeNodeHtml = "</ul></li>";

        #endregion

        #region props
        public string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        public string MenuUrl
        {
            get { return _menuUrl; }
            set { _menuUrl = value; }
        }
        public StringBuilder CloseNodeHtml
        {
            get { return new StringBuilder(_closeNodeHtml); }
        }

        public virtual bool IsLastChildNode { get { return false; } }
        #endregion

        public Node(string menuName, string menuUrl)
        {
            this._menuName = menuName;
            this._menuUrl = menuUrl;
        }

        public abstract StringBuilder ReturnNodeHTML{ get;}

    }

    public class TeamNode : Node
    {
        public override StringBuilder ReturnNodeHTML
        {
            get { return new StringBuilder(String.Format("<li class=\"team-node\" aria-level=\"1\"><i></i><a><span>{0}</span></a><ul>", this.MenuName)); }
        }

        public TeamNode(string menuName, string menuUrl)
            : base(menuName, menuUrl)
        {

        }
    }

    public class ParentNode : Node
    {
        public override StringBuilder ReturnNodeHTML
        {
            get { return new StringBuilder(String.Format("<li class=\"group-expand group-hide\" aria-level=\"2\"><i></i><a><span>{0}</span></a><ul class=\"parent-node\">", this.MenuName)); }
        }

        public ParentNode(string menuName, string menuUrl)
            : base(menuName, menuUrl)
        {

        }
    }

    public class ChildNode : Node
    {

        public override StringBuilder ReturnNodeHTML
        {
            get { return new StringBuilder(String.Format("<li class=\"group-expand group-hide\" aria-level=\"3\" class=\"lowest-child\"><i></i><a href=\"{0}\" >{1}</a></li>", this.MenuUrl, this.MenuName)); }
        }

        public ChildNode(string menuName, string menuUrl)
            : base(menuName, menuUrl)
        {

        }

        public override bool IsLastChildNode
        {
            get { return true; }
        }
    }


}
