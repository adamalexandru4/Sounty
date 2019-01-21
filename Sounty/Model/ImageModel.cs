using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.Model
{
    class ImagesModel
    {
        private static ImagesModel instance;

        #region Constructor

        public static ImagesModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImagesModel();
                return instance;
            }
        }

        public ImagesModel()
        {
        }

        #endregion
        
        public string GetImagePath(int imageId)
        {
            string imagePath;

            if (imageId == 0)
                return string.Empty;

            using (var context = new DataAccess.SountyDB())
            {
                try
                {
                    imagePath = (from image in context.Images
                                  where image.imageId == imageId
                                  select image.imagePath).Single();

                    return imagePath;
                }
                catch(Exception)
                {
                    return string.Empty;
                }
              };
        }
    }
}
