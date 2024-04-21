using abstractests.Models;
using AutoMapper;
using FluentValidation;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace abstractests
{



    
    /********************/

    public class A2
    {
    }

    public class B2 : A2
    {
    }

    public class C2 : A2
    {
    }

    public class Destination
    {
        public List<A2> Entities { get; set; }
    }

    public abstract class MugItem
    {
        public string TypeName { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }

    public class Cartridge : MugItem
    {

    }

    public class Carrier : MugItem
    {

    }

    public class Mug
    {
        public int Id { get; set; }
        public List<MugItem> MugItems { get; set; }
    }


    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }

    public abstract class Worker
    {
        public Guid Id { get; set; }
    }

    public class Fireman : Worker
    {
        public string Station { get; set; }
    }

    public class Cleaner : Worker
    {
        public string FavoriteSolvent { get; set; }
    }


    public class AddReportViewModel
    {
        public string Name { get; set; }
        public List<AddFiremanViewModel> Firemen { get; set; }
        public List<AddCleanerViewModel> Cleaners { get; set; }
    }

    public class AddFiremanViewModel
    {
        public string Station { get; set; }
    }

    public class AddCleanerViewModel
    {
        public string FavoriteSolvent { get; set; }
    }


    public interface ICoverage
    {
        string Name { get; set; }
        string Code { get; set; }
    }

    public class CoverageA : ICoverage
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Current { get; set; }
    }

    public class CoverageB : ICoverage
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool HasRecord { get; set; }
    }

    public class Application
    {
        public int ApplicationId { get; set; }
        public string Code { get; set; }
        public List<ICoverage> Coverages { get; set; }

        public Application()
        {
            Coverages = new List<ICoverage>();
        }
    }

    public class StagingDto
    {
        public string Referrer { get; set; }
        public string Code { get; set; }
        public CoverageADto CoverageA { get; set; }
        public CoverageBDto CoverageB { get; set; }
    }

    public class CoverageADto
    {
        public string Current { get; set; }
    }

    public class CoverageBDto
    {
        public bool HasRecord { get; set; }
    }


    public abstract class User
    {
        /* properties */
    }

    public class Teacher : User
    {

    }

    public class Student : User
    {

    }

    public enum UserType
    {
        Teacher,
        Student
    }

    public class UserVM
    {
        /* Properties of User */
        public UserType UserType { get; set; }
    }


    public  class  asdas
    {

        public void adssds()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
            

            });


        }
    }

}
