namespace Gecko.Windows
{
    internal sealed class JumpListLink
        : JumpListItem
    {
        private nsIJumpListLink _link;

        internal JumpListLink(nsIJumpListLink item)
            : base(item)
        {
            _link = item;
        }
    }
}