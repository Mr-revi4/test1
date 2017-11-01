namespace WinService
{
    partial class WinService
    {       
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code that is automatically created by the component designer

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "WinService";
        }

        #endregion
    }
}
