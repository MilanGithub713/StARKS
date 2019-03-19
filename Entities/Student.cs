using System;
using System.Collections.Generic;

namespace StARKS.Entities
{
    /// <summary>
    /// The Student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the Student Id.
        /// </summary>
        /// <value>
        /// The Student Id.
        /// </value>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the First name.
        /// </summary>
        /// <value>
        /// The First name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name.
        /// </summary>
        /// <value>
        /// The Last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>
        /// The Address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>
        /// The City.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>
        /// The State.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Date Of Birthday.
        /// </summary>
        /// <value>
        /// The Date Of Birthday.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>
        /// The Gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the Marks.
        /// </summary>
        /// <value>
        /// The Marks.
        /// </value>
        public virtual List<Mark> Marks { get; set; }
    }
}
