﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string detailsInfo;

        public ContactData (string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = null;
           
        }

        public string Firstname { get; set; }
        
        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        { 
            get
            { 
                if (allPhones!=null)
                {
                    return allPhones;
                }
                else
                {
                    
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } 
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                    
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string DetailsInfo
        {
            get
            {
                if (detailsInfo != null)
                {
                    return detailsInfo;
                }
                else
                {

                    return (Firstname + Middlename + Lastname 
                                + Address
                                + HomePhone.Replace(" ", "") 
                                + MobilePhone.Replace(" ", "") 
                                + WorkPhone.Replace(" ", "")
                                + Email.Replace(" ", "") 
                                + Email2.Replace(" ", "") 
                                + Email3.Replace(" ", ""))
                                .Trim();
                }
            }
            set
            {
                detailsInfo = value;
            }
        }
        
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";// phone.Replace(" ","").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Id { get; set; }
        

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            // если firstname равно, то сравниваем lastname
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname.Equals(other.Firstname) && Lastname.Equals(other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "firstname=" + Firstname + " lastname=" + Lastname;
        }

    }
}
