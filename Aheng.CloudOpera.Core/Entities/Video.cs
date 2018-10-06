using System;
using System.Collections.Generic;
using System.Text;

namespace Aheng.CloudOpera.Core.Entities
{
    public class Video
    {
        public Guid VideoId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime UploadTime { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Size { get; set; }
        public string VideoName { get; set; }
        public string Tag { get; set; }
        public string Cateroty { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 资源网址
        /// </summary>
        public string MediaUrl { get; set; }
        /// <summary>
        /// 擂台赛人气
        /// </summary>
        public int Votes { get; set; }
        /// <summary>
        /// 获得的赏银
        /// </summary>
        public int SilverDollar { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 视频播放量
        /// </summary>
        public int VV { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int Favorites { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Like { get; set; }
        /// <summary>
        /// 点灭数
        /// </summary>
        public int Dislike { get; set; }
        /// <summary>
        /// 封面图网址
        /// </summary>
        public string CoverPicUrl { get; set; }


        public User Owner { get; set; }
    }
}
