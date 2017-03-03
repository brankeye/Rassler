﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using rassler.backend.domain.Data.Models;
using rassler.backend.domain.Data.Models.Base;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class ClassesController : CoreController<Class>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Class>))]
        public async Task<IHttpActionResult> Get()
        {
            var repository = GetSecuredRepository<Class>();
            var entities = await repository.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var repository = GetSecuredRepository<Class>();
            var entity = await repository.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.Data.Models.DTOs.Class entity)
        {
            if (ModelState.IsValid)
            {
                var repository = GetSecuredRepository<Class>();
                var mapper = GetMapper();
                var mappedEntity = mapper.Map<domain.Data.Models.Class>(entity);
                var updatedEntity = await repository.InsertOrUpdateAsync(mappedEntity);
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content);
                return response;
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var repository = GetSecuredRepository<Class>();
            var deletedEntity = await repository.DeleteAsync(id);
            var response = GetResponse(deletedEntity.ResultCode);
            return response;
        }
    }
}