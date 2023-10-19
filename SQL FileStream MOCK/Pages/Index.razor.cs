using BuisnesLogic;
using Microsoft.AspNetCore.Components.Forms;
using Models;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace SQL_FileStream_MOCK.Pages
{
    public partial class Index
    {
        // this string holds my Image after i get it from the DB
        string imageString { get; set; }

        //This is my Image repo where i upload and download the images
        public ImageRepo repo;
        public Index()
        {
            repo = new();
        }

        //this Method is called when ever my onchanged event is triggered from the UI
        // where i take an InputFileChangeEventArgs as a parameter to store the file the user uploads
        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            //in this variable i extrat the file from the InputFileChangeEventArgs
            var file = e.File;
        
                if (file != null)
                {
                    //here i check on the content type that the user has uploaded and i verify that it is an image.
                    if (file.ContentType.Contains("image"))
                    {
                        //here i create an open memory stream so i can extract the users picture
                        using (var memoryStream = new MemoryStream())
                        {
                            //here i extrat the image from the file and copy it into memory stream
                             await file.OpenReadStream(1000000000000000).CopyToAsync(memoryStream);

                        //This section can be used for Altering the Image with tools like SixLabors.ImageSharp;
                        // if you want to reshape, rezise or compress the image.
                        //using (Image image = Image.Load(memoryStream.ToArray()))
                        //{
                        //    // Resize the image to half of its width and height keeping the aspect ratio
                        //    image.Mutate(x => x.Resize(new ResizeOptions
                        //    {
                        //        Size = new Size(image.Width / 5, image.Height / 5),
                        //        Mode = ResizeMode.Max
                        //    }));

                        //    image.Save(memoryStream, new PngEncoder());
                        //}

                        //here i call my upload method in my repo with the image that is converted into a byte array
                        await repo.InsertImageAsync(memoryStream.ToArray());
                    }

                    //This is just for testing purpuses, but here i load an image from my DB 
                    //where i send an index as the parameter
                    Images img = await repo.GetImageAsync(21);

                    if (img != null)
                    {
                        //in order to show the picture to the user after getting it from my DB
                        //i convert it over to a Base64string
                        imageString = Convert.ToBase64String(img.ImageURl);

                        //tells the Webpage that a statehasbeenchanged
                        StateHasChanged();
                        } 
                    }

                }
        }
      
        

    }
}

