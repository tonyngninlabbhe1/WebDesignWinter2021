public static class BusinessRules
{
    public static bool isSpecial(Student student) => 
        student.email_address.ToString().StartsWith(bestStudent);

    // public static bool isOnSale(Product product) =>
    //     product.Name.ToLower().StartsWith(onSaleKey);

    // public static int lowStudentCount = 3;

    public static string bestStudent = "f";
}
