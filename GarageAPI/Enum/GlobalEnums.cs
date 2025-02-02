namespace GarageAPI.Enum
{
    public enum UserType
    {
        Admin = 1,
        Customer = 2,
        Engineer = 3,
        Employee = 4,
        Guest = 5
    }

    public enum EnableAccess
    {
        Enable = 1,
        RestrictedAccess = 2,
        Disable = 3
    }

    public enum EngineType
    {
        Petrol = 1,
        Diesel = 2,
        HybridPetrol = 3,
        HybdridDiesel = 4,
        LNG = 5,
        CNG = 6,
        Electric = 7
    }

    public enum FileType
    {
        Image = 1,
        Document = 2
    }

    public enum ResponseCode
    {
        Success = 200,
        NoUserFound = 801,
        WrongPassword = 802,
        BlockedUser = 803,
        FailedEmail = 804
    }

    public enum FileExtension
    {
        PDF = 1,
        DOC = 2,
        DOCX = 3,
        JPG = 4,
        JPEG = 5,
        PNG = 6
    }

    public enum Colors
    {
        AliceBlue,
        AntiqueWhite,
        Aqua,
        Aquamarine,
        Azure,
        Beige,
        Bisque,
        Black,
        BlanchedAlmond,
        Blue,
        BlueViolet,
        Brown,
        BurlyWood,
        CadetBlue,
        Chartreuse,
        Chocolate,
        Coral,
        CornflowerBlue,
        Cornsilk,
        Crimson,
        Cyan,
        DarkBlue,
        DarkCyan,
        DarkGoldenrod,
        DarkGray,
        DarkGreen,
        DarkKhaki,
        DarkMagenta,
        DarkOliveGreen,
        DarkOrange,
        DarkOrchid,
        DarkRed,
        DarkSalmon,
        DarkSeaGreen,
        DarkSlateBlue,
        DarkSlateGray,
        DarkTurquoise,
        DarkViolet,
        DeepPink,
        DeepSkyBlue,
        DimGray,
        DodgerBlue,
        Feldspar,
        Firebrick,
        FloralWhite,
        ForestGreen,
        Fuchsia,
        Gainsboro,
        GhostWhite,
        Gold,
        Goldenrod,
        Gray,
        Green,
        GreenYellow,
        Honeydew,
        HotPink,
        IndianRed,
        Indigo,
        Ivory,
        Khaki,
        Lavender,
        LavenderBlush,
        LawnGreen,
        LemonChiffon,
        LightBlue,
        LightCoral,
        LightCyan,
        LightGoldenrodYellow,
        LightGray,
        LightGreen,
        LightPink,
        LightSalmon,
        LightSeaGreen,
        LightSkyBlue,
        LightSlateBlue,
        LightSlateGray,
        LightSteelBlue,
        LightYellow,
        Lime,
        LimeGreen,
        Linen,
        Magenta,
        Maroon,
        MediumAquamarine,
        MediumBlue,
        MediumOrchid,
        MediumPurple,
        MediumSeaGreen,
        MediumSlateBlue,
        MediumSpringGreen,
        MediumTurquoise,
        MediumVioletRed,
        MidnightBlue,
        MintCream,
        MistyRose,
        Moccasin,
        NavajoWhite,
        Navy,
        OldLace,
        Olive,
        OliveDrab,
        Orange,
        OrangeRed,
        Orchid,
        PaleGoldenrod,
        PaleGreen,
        PaleTurquoise,
        PaleVioletRed,
        PapayaWhip,
        PeachPuff,
        Peru,
        Pink,
        Plum,
        PowderBlue,
        Purple,
        Red,
        RosyBrown,
        RoyalBlue,
        SaddleBrown,
        Salmon,
        SandyBrown,
        SeaGreen,
        SeaShell,
        Sienna,
        Silver,
        SkyBlue,
        SlateBlue,
        SlateGray,
        Snow,
        SpringGreen,
        SteelBlue,
        Tan,
        Teal,
        Thistle,
        Tomato,
        Transparent,
        Turquoise,
        TVBlack,
        TVWhite,
        Violet,
        VioletRed,
        Wheat,
        White,
        WhiteSmoke,
        Yellow,
        YellowGreen
    }

    public enum ServiceAppointmentStatus
    {
        Pending = 1,
        Cancelled = 2,
        Completed = 3
    }
}