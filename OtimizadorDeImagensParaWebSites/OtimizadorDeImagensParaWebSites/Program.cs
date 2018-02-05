using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtimizadorDeImagensParaWebSites
{
    class Program
    {
        static void Main(string[] args)
        {
            var diretorioImagens = new DirectoryInfo(@"D:\DiretorioImagens");
            var pastaParaSalvarThumbs = new DirectoryInfo(@"D:\DiretorioImagens\thumbs");
            foreach (FileInfo file in diretorioImagens.GetFiles())
            {
                using (var img = Image.FromFile(file.FullName))
                {
                    //Este exemplo está criando apenas thumbs de um diretorio de imagens
                    //Mas pode ser utilizado para otimizar imagens com resolução maiores.
                    //Por exemplo: new Size(900,900)
                    SaveToFolder(img, file.Name, new Size(200, 200), pastaParaSalvarThumbs + @"\" + file.Name);
                    Console.WriteLine("Imagem salva: {0}", file.Name);
                }
            }

            Console.ReadKey();

        }

        private static Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize;

            return finalSize;
        }


        private static void SaveToFolder(Image img, string fileName, Size newSize, string pathToSave)
        {
            Size imgSize = NewImageSize(img.Size, newSize);
            using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                newImg.Save(pathToSave, img.RawFormat);
            }
        }
    }
}
