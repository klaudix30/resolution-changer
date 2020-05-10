using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab07
{
    class ResolutionChanger
    {
        private String inputdir;
        private String outputdir;
        private int resX;
        private int resY;
        private List<string> fileNames;

       
        public ResolutionChanger(int resX,int resY, String inputdir, String outputdir)
        {
            this.resX = resX;
            this.resY = resY;
            this.outputdir = outputdir;
            this.inputdir = inputdir;
            fileNames = new List<string>();
        }

        public void changeRes(string fileName)
        {

            Image image = Image.FromFile(inputdir+"\\"+fileName);
            Bitmap bitmap = new Bitmap(image, new Size(resX, resY));
            var file=checkAvailability(fileName);
            bitmap.Save(outputdir+"\\"+file);
            


        }
        public String checkAvailability(string fileName)
        {
           String result;
           String file=fileName;
           int i = 0;
            while (File.Exists(outputdir + "\\"+file))
            {
                i++;
                result = Path.GetFileNameWithoutExtension(fileName) +"_" + i;
                file = Path.ChangeExtension(result, Path.GetExtension(fileName));
           
              
            }
            return file;

        }
        public void getFiles()
        {
            
            string[] files = Directory.GetFiles(inputdir);
            foreach (string fileName in files)
            {
                checkExt(fileName);
            }

         
        }

        public void checkExt(string fileName)
        {
            string[] exts = new string[8] { ".JPG", ".jpg", ".jpeg", ".JPEG",".png",".PNG",".bmp",".BMP"};

            if(exts.Contains(Path.GetExtension(fileName))){
				changeRes(Path.GetFileName(fileName));
			}

        }
       
        
    }
}

