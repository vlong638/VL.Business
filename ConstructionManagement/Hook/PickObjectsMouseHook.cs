namespace PmSoft.ConstructionManagement.Hook
{
    /// <summary>
    /// 
    /// <remarks>作者:黄勇亮，创建日期:2016/10/19 17:08:30，修改日期:</remarks>
    /// </summary>
    public class PickObjectsMouseHook : MouseHookExt
    {
        public enum OKModeENUM { Objects, Object }
        private ButtonHandle handle = null;
        private OKModeENUM mode = OKModeENUM.Objects;

        public PickObjectsMouseHook()
        {
            handle = new ButtonHandle();
            this.RightButtonDown += PickObjectsMouseHook_RightButtonDown;
            this.RightButtonUp += PickObjectsMouseHook_RightButtonUp;
        }

        public void InstallHook(OKModeENUM mode)
        {
            this.mode = mode;
            this.InstallHook();
        }

        bool PickObjectsMouseHook_RightButtonDown(System.Drawing.Point pt)
        {
            return true;
        }

        bool PickObjectsMouseHook_RightButtonUp(System.Drawing.Point pt)
        {
            this.UninstallHook();

            if (this.mode == OKModeENUM.Objects)
            {
                handle = new ButtonHandle();
                handle.Mouse_RightButtonDown(pt);
            }
            else
                Common.RevitClass.Keyboard.RevitKeyboardCommand.PostEscCommand();

            return true;
        }
    }
}