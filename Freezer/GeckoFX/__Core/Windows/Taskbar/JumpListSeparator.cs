namespace Gecko.Windows
{
    internal sealed class JumpListSeparator
        : JumpListItem
    {
        private nsIJumpListSeparator _separator;

        internal JumpListSeparator(nsIJumpListSeparator item)
            : base(item)
        {
            _separator = item;
        }
    }
}