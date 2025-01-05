using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace SiteCostProApp.Classes
{
    [FirestoreData] // Specifies that the class can be used with Firestore
    public class EquipmentProperty
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public string Equipment_Name { get; set; }

        [FirestoreProperty]
        public string Usage_Time { get; set; }

        [FirestoreProperty]
        public string Unit_Price { get; set; }

        [FirestoreProperty]
        public string Total { get; set; }

       

    }

    [FirestoreData] // Specifies that the class can be used with Firestore
    public class LabourProperty
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public string Labour_Type { get; set; }

        [FirestoreProperty]
        public string Work_Time { get; set; }

        [FirestoreProperty]
        public string Unit { get; set; }

        [FirestoreProperty]
        public double UnitWage { get; set; }

        [FirestoreProperty]
        public int Total { get; set; }

       
    }

    [FirestoreData] // Specifies that the class can be used with Firestore
    public class MaterialProperty
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public string Material_Name { get; set; }

        [FirestoreProperty]
        public string Unit { get; set; }

        [FirestoreProperty]
        public string Unit_Price { get; set; }

        [FirestoreProperty]
        public string Quantity { get; set; }

        [FirestoreProperty]
        public string Total { get; set; }

        
    }

    [FirestoreData] // Specifies that the class can be used with Firestore
    public class MiscellaneousProperty
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public string Item_Name { get; set; }

        [FirestoreProperty]
        public int Quantity { get; set; }

        [FirestoreProperty]
        public double Unit_Price { get; set; }

        [FirestoreProperty]
        public double Total { get; set; }

       
    }

 


    [FirestoreData] // Specifies that the class can be used with Firestore
    public class ProjectDetailsPropeties
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public string ProjectName { get; set; }

        [FirestoreProperty]
        public List<MaterialProperty> Materials { get; set; }

        [FirestoreProperty]
        public List<EquipmentProperty> Equipments { get; set; }

        [FirestoreProperty]
        public List<LabourProperty> Labour { get; set; }

        [FirestoreProperty]
        public List<MiscellaneousProperty> Miscellaneous { get; set; }

   
    }

    [FirestoreData] // Specifies that the class can be used with Firestore
    public class Root
    {
        [FirestoreProperty] // Marks the property for Firestore serialization
        public List<ProjectDetailsPropeties> Projects { get; set; }
    }
}
