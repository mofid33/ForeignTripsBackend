using System;
using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace ShenaseMeliBac.Profiles
{
	public class Agent:Profile
	{
		public Agent()
		{

            //CreateMap<Entities.Organization, Model.OrganizationTbl>();
            //CreateMap<Model.OrganizationTbl, Entities.Organization>();
            CreateMap<AgentTbl,AgentDto>();
            //CreateMap<Model.ManagerStatusTbl, Entities.ManagerStatusDto>();

        }

    }
}