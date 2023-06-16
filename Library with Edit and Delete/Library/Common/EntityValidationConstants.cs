namespace Library.Common
{
    using Microsoft.EntityFrameworkCore;

    [Comment("EntityValidationConstants")]
    public class EntityValidationConstants
    {
        [Comment("EntityValidationConstants for Book entity")]
        public class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 10;
            public const int UserIdMaxLength = 450;
        }

        [Comment("EntityValidationConstants for Category entity")]
        public class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

    }
}

/*
• Has Id – a unique integer, Primary Key
• Has Name – a string with min length 5 and max length 50 (required)
• Has Books – a collection of type Books
 */


/*
• Has Id – a unique integer, Primary Key
• Has Title – a string with min length 10 and max length 50 (required)
• Has Author – a string with min length 5 and max length 50 (required)
• Has Description – a string with min length 5 and max length 5000 (required)
• Has ImageUrl – a string (required)
• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
• Has CategoryId – an integer, foreign key (required)
• Has Category – a Category (required)
• Has UsersBooks – a collection of type IdentityUserBook
 */
