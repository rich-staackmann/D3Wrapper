//
// @desc The class contains functions that retrieve data about followers.
// examples include GetAllFollowerInformation()
// @author Richard Staackmann

using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using D3Wrapper.ResponseObjects;

namespace D3Wrapper
{
    public class FollowerInformation
    {
        private const string baseURL = "http://us.battle.net/api/d3/data/follower/";
        private static WebClient client = new WebClient();

        // @desc Gets all the possible data on a follower
        // @params string name - a string that identifies the follower
        // @return D3Follower - a custom class that holds all follower data
        public static D3Follower GetAllFollowerInformation(string name)
        {
            try
            {
                Stream jsonSource = client.OpenRead(baseURL + name);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(D3Follower));
                D3Follower follower = (D3Follower)serializer.ReadObject(jsonSource);

                return follower;
            }
            catch (Exception e)
            {
                return CreateNullFollower();
            }
            finally
            {
                client.Dispose();
            }
        }

        // @desc create a follower that has no meaningful data, return this instead of NULL
        // @params none
        // @return follower - a custom class that holds all follower data
        public static D3Follower CreateNullFollower()
        {
            return new D3Follower()
            {
                skills = new Skills() { passive = new Skill[1] { new Skill() }, active = new Skill[1] { new Skill() } }
            };
        }
    }
}
