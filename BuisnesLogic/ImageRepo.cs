using Database;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BuisnesLogic
{
    public class ImageRepo
    {

        EntityContext dB;
        public ImageRepo()
        {
            dB = new();
        }



        public async Task<bool> InsertImageAsync(byte[] img)
        {
            Images image = new Images { ImageURl = img };
            await dB.Images.AddAsync(image);
            var success = await dB.SaveChangesAsync();
            if (success > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Images> GetImageAsync(int id)
        {
            if (id != null)
            {
                Images img = await dB.Images.FirstOrDefaultAsync(x => x.ImageID == id);
                if (img != null)
                {
                    return img;
                }
            }
            return null;
        }


    }
}