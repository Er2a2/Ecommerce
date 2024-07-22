namespace ProjectTerm2
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\image\\Teacher\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }
        public string uploadImage(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\image\\course\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        } 
        public string uploadvideo(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\videos\\course\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            //اگه بعدا بخوایم ب هاست متصلش کنیم دیگه لازم نیست ک بخوایم بگیم پوشه c
            //و این داستانا فقط اطلاعات مربوط ب عکس رو میخوایم که این میگه از اونجا دقیقا بعد اطلاعات پوشه ببرش و فقط اطلاعات عکس رو بده
            path = path.Split("wwwroot")[1];
            return file.FileName;
        }
        
    }
}
