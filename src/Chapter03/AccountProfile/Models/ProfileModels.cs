using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AccountProfile.Models
{
    public class Profile
    {
        public Profile(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class ProfileEditModel
    {
        public ProfileEditModel(Profile profile)
        {
            Username = profile.Username;
            FirstName = profile.FirstName;
            LastName = profile.LastName;
            Email = profile.Email;
        }

        public ProfileEditModel()
        {
        }

        public string Username { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
    }

    public interface IProfileRepository
    {
        Profile[] GetAll();
        Profile Find(string username);
        void Add(Profile profile);
    }

    public class ProfileRepository : IProfileRepository
    {
        private static List<Profile> _profiles = new List<Profile>();

        public Profile[] GetAll()
        {
            return _profiles.ToArray();
        }

        public Profile Find(string username)
        {
            var profile = _profiles.FirstOrDefault(p => p.Username == username);
            if (profile == null)
            {
                profile = new Profile(username);
                Add(profile);
            }

            return profile;
        }

        public void Add(Profile profile)
        {
            _profiles.Add(profile);
        }
    }
}