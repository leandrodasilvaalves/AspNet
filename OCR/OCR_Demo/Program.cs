using System;
using Tesseract;

namespace OCR_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var arqueiroVerde1 = Environment.CurrentDirectory + @"\Imagens\arqueiro-verde-01.JPG";
            var arqueiroVerde2 = Environment.CurrentDirectory + @"\Imagens\arqueiro-verde-02.jpg";
            try
            {
                LerImagem(arqueiroVerde1);

                Console.WriteLine(new String('-',80));

                LerImagem(arqueiroVerde2);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static void LerImagem(string imagem, string lang = "por") 
        {
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", lang, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagem))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            Console.WriteLine("Taxa de de Precisao: {0}", page.GetMeanConfidence());
                            Console.WriteLine("Texto: \r\n{0}", texto);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
