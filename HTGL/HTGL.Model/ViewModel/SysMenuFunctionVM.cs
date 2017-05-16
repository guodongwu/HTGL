namespace HTGL.Model
{
    public class SysMenuFunctionVM
    {
        public  int MFId { get; set;}
        public int FunctionId { get; set; }
        public int MenuId { get; set; }
        public  string FunctionName { get; set; }
        public string ControllerName { get; set; }
        public  string ActionName { get; set; }
        public  bool IsVisible { get; set; }
        public string FunctionIcon { get; set; }
        public  string MenuName { get; set; }

        public SysMenuFunctionVM()
        {

        }
    }
}