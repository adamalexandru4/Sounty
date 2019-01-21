using Sounty.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.Model
{
    public class PlaylistModel : ViewModelBase
    {
        #region Private Fields

        private int playlistId;
        private string playlistName;
        private DateTime createdDate;
        private DateTime updatedDate;
        private UserModel user;
        private int nrFollowers;
        private List<int> imagesCoverId;
        private int imageCoverId;
        private string description;

        #endregion

        #region Constructor

        public PlaylistModel(int playlistId)
        {
            ImagesCoverId = new List<int>();

            FillInformations(playlistId);
        }

        #endregion

        #region Public Fields

        public int PlaylistId { get => playlistId; set => playlistId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public int NrFollowers { get => nrFollowers; set => nrFollowers = value; }
        public string Description { get => description; set => description = value; }
        public string PlaylistName { get => playlistName; set => playlistName = value; }
        public List<int> ImagesCoverId { get => imagesCoverId; set => imagesCoverId = value; }
        public UserModel User { get => user; set => user = value; }
        public int ImageCoverId { get => imageCoverId; set => imageCoverId = value; }

        #endregion

        #region Private Methods

        void FillInformations(int playlistId)
        {
            using (var context = new DataAccess.SountyDB())
            {
                try
                {
                    var playlist = (from playlistItem in context.Playlists
                                    where playlistItem.playlistId == playlistId
                                    select playlistItem).Single();

                    this.PlaylistId = playlistId;
                    this.PlaylistName = playlist.playlistName;
                    this.CreatedDate = playlist.createdDate ?? new DateTime(2019, 1, 18);
                    this.UpdatedDate = playlist.updatedDate ?? new DateTime(2019, 1, 18);
                    this.NrFollowers = playlist.followers ?? 0;
                    this.Description = playlist.descriptionText ?? string.Empty;
                    this.ImageCoverId = playlist.imageId ?? 0;

                    var user = (from userItem in context.UserInfoes
                                where userItem.userInfoId == playlist.userId
                                select userItem).Single();

                    this.user = new UserModel(user);

                    if (this.ImageCoverId == 0)
                    {
                        var imagesPath = (from item in context.PlaylistTracks
                                          join trackItem in context.Tracks on item.trackId equals trackItem.trackId
                                          join imageItem in context.Images on trackItem.imageId equals imageItem.imageId
                                          where item.playlistId == playlistId
                                          select imageItem.imageId);

                        if (imagesPath.Count() < 4)
                        {
                            ImagesCoverId.Add(imagesPath.First());
                        }
                        else
                        {
                            int count = 0;
                            foreach (var path in imagesPath)
                            {
                                if (count == 4)
                                    break;

                                ImagesCoverId.Add(path);
                            }
                        }
                    }
                    else
                    {
                        ImagesCoverId.Add(this.ImageCoverId);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            };
        }

        #endregion
    }
}
