namespace Gecko.Windows
{
    internal sealed class JumpListShortcut
        : JumpListItem
    {
        private nsIJumpListShortcut _shortcut;

        internal JumpListShortcut(nsIJumpListShortcut item)
            : base(item)
        {
            _shortcut = item;
        }
    }
}