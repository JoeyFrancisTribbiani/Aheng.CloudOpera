using Aheng.CloudOpera.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Infrastructrue.DataBase
{
    public class OperaContextSeed
    {
        public static async Task SeedAsync(OperaContext operaContext,
            ILoggerFactory loggerFactory,int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                // TODO: Only run this if using a real database
                // myContext.Database.Migrate();

                if (!operaContext.Users.Any())
                {
                    operaContext.AddRange(
                        new List<User>()
                        {
                            new User
                            {
                                UserId = new Guid("5F40AFF9-7A5F-4CE9-BA87-4D336E5C464F"),
                                UserName = "ceshi1",
                                Dislike = 23,
                                Like = 200,
                                SilverDollar =10000,
                                Favorites = 89,
                                Followers =90,
                                Following = 538,
                                Medias = 90,
                                Password = "123123",
                                HeadShotUrl = "",
                                Videos = new List<Video>
                                {
                                    new Video
                                    {
                                        VideoName = "四郎探母",
                                        OwnerId = new Guid("5F40AFF9-7A5F-4CE9-BA87-4D336E5C464F"),
                                        VideoId = new Guid("BB1C2818-FCD0-4155-91D3-7753C2964703"),
                                        Tag = "Rap",
                                        Size = 120000,
                                        UploadTime = new DateTime()
                                    },
                                    new Video
                                    {
                                        VideoName = "叫张生躲在棋盘之下",
                                        OwnerId = new Guid("5F40AFF9-7A5F-4CE9-BA87-4D336E5C464F"),
                                        VideoId = new Guid("B12F7375-A321-4EA0-87EA-723824BE7DB8"),
                                        Tag = "爱情经典",
                                        Size = 20000,
                                        UploadTime = new DateTime()
                                    },
                                    new Video
                                    {
                                        VideoName = "沙家浜",
                                        OwnerId = new Guid("5F40AFF9-7A5F-4CE9-BA87-4D336E5C464F"),
                                        VideoId = new Guid("2C8B209E-013B-4E2A-9F8A-582D4275EEE2"),
                                        Tag = "红色经典",
                                        Size = 560000,
                                        UploadTime = new DateTime()
                                    }
                                }
                            },
                            new User
                            {
                                UserId = new Guid("5F40AFF9-7A5F-4CE9-BA87-4D336E5C464F"),
                                UserName = "ceshi1",
                                Dislike = 23,
                                Like = 200,
                                SilverDollar =10000,
                                Favorites = 89,
                                Followers =90,
                                Following = 538,
                                Medias = 90,
                                Password = "123123",
                                HeadShotUrl = "",
                                Videos = new List<Video>
                                {
                                    new Video
                                    {
                                        VideoName = "武家坡",
                                        OwnerId = new Guid("AFCC77FD-CBD7-4E62-BCF7-013CED748911"),
                                        VideoId = new Guid("2F4C7D5C-42A1-429C-9B4D-8F90B0DC00E1"),
                                        Tag = "Rap",
                                        Size = 784302,
                                        UploadTime = new DateTime()
                                    },
                                    new Video
                                    {
                                        VideoName = "叫张生躲在棋盘之下",
                                        OwnerId = new Guid("AFCC77FD-CBD7-4E62-BCF7-013CED748911"),
                                        VideoId = new Guid("1C7C0AA4-4CF5-4F3B-B397-B0018E9A2F18"),
                                        Tag = "爱情经典",
                                        Size = 3400,
                                        UploadTime = new DateTime()
                                    },
                                    new Video
                                    {
                                        VideoName = "智取威虎山",
                                        OwnerId = new Guid("AFCC77FD-CBD7-4E62-BCF7-013CED748911"),
                                        VideoId = new Guid("7EFEB2C2-4D93-41F7-98C3-CEED16C1B8F7"),
                                        Tag = "红色经典",
                                        Size = 98593,
                                        UploadTime = new DateTime()
                                    }
                                }
                            }

                        });
                    await operaContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(retryForAvailability < 10)
                {
                    retryForAvailability++;

                    var logger = loggerFactory.CreateLogger<OperaContext>();
                    logger.LogError(ex.Message);
                    await SeedAsync(operaContext, loggerFactory, retryForAvailability);
                }

                throw;
            }
        }
    }
}
