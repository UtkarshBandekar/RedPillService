using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace RedPillService
{
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {

        [OperationContract]
        Guid WhatIsYourToken();

        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);


        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);

        [OperationContract]
        [FaultContract(typeof(InvalidDataContractException))]
        TriangleType WhatShapeIsThis(int a, int b, int c);
        
    }


    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType : int
    {

        [EnumMember]
        Error = 0,// inputs can't produce a triangle

        [EnumMember]
        Equilateral = 1,// all sides are the same length

        [EnumMember]
        Isosceles = 2, // two sides are the same length and one differs

        [EnumMember]
        Scalene = 3,// no two sides are the same length
    }
}
