using System;
using System.Collections.Generic;
using System.Text;

namespace Aheng.CloudOpera.Core.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int Following { get; set; }
        /// <summary>
        /// 粉丝数
        /// </summary>
        public int Followers { get; set; }
        /// <summary>
        /// 视频数
        /// </summary>
        public int Medias { get; set; }
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
        /// 赏银数
        /// </summary>
        public int SilverDollar { get; set; }
        /// <summary>
        /// 头像图片网址
        /// </summary>
        public string HeadShotUrl { get; set; }

        public ICollection<Video> Videos { get; set; }
    }
}
