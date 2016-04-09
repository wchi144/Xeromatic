using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet=Xeromatic.Models.Tweet;
using Xeromatic.Services;

namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "MvOVsv7I2DBeiV7DIpMmZ7gWg",
                ConsumerSecret = "qHwxUx6nSzxmHRzWtktbqp52LdVWOyZQOQMa5N2WgJMJdsM8k6",
                AccessToken = "718575014337904640-FVlrCqkISK1rPi1rQsr2qjiApzdNgIy",
                AccessTokenSecret = "KxBxq3a0kO9VUY1sBoG6yCKvAgOhzvqDUny1zCAAAunF3"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () =>
            {
                return Timeline.GetUserTimeline("Xero",10);
            });

            if (tweets.Any())
            {
                return tweets.Select(t => new Tweet

                {
                    Id = t.Id,
                    Text = t.Text

                });
            
            }

            return new List<Tweet>();

        }

    }
}