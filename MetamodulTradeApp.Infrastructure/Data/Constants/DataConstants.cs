using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public const int PostTitleMinLength = 5;
        public const int PostTitleMaxLength = 30;
        public const int PostDescriptionMinLength = 10;
        public const int PostDescriptionMaxLength = 300;


        public const int CommentTextMinLength = 3;
        public const int CommentTextMaxLength = 200;

        public const int ClientRequestTopicMinLength = 5;
        public const int ClientRequestTopicMaxLength = 30;
        public const int ClientRequestMessageMinLength = 10;
        public const int ClientRequestMessageMaxLength = 400;
        public const int ClientRequestPhoneNumberMinLength = 7;
        public const int ClientRequestPhoneNumberMaxLength = 10;

        public const int ProductNameMinLength = 5;
        public const int ProductNameMaxLength = 30;
        public const int ProductDescriptionMinLength = 20;
        public const int ProductDescriptionMaxLength = 200;
        public const int ProductCategoryMaxLength = 20;

        public const string DateFormat = "dd:MM:yyyy";

    }
}
