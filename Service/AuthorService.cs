﻿using AutoMapper;
using Core.Dtos.Constants;
using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Author;
using Core.Interfaces.GenericInterfaces;
using Core.Interfaces.PageInterfaces;
using Core.Interfaces.PageInterfaces.RepositoryInterfaces;
using Core.Models.PageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericCrudRepository<Author> _genericAuthorCrudRepository;
        private readonly IMapper _mapper;
        private IAuthorServiceRepository _authorServiceRepository;

        public AuthorService(IGenericCrudRepository<Author> genericAuthorCrudRepository, IMapper mapper, IAuthorServiceRepository authorServiceRepository)
        {
            _genericAuthorCrudRepository = genericAuthorCrudRepository;
            _mapper = mapper;
            _authorServiceRepository = authorServiceRepository;
        }

        public async Task<GenericResponseDto<NoContent>> CreateAuthorWithCrossTables(GenericInputDto<CreateAuthorWithCrossDto> tEntities)
        {
            Author createdEntity = await _genericAuthorCrudRepository.Insert(_mapper.Map<Author>(tEntities.Data.CreateAuthor));
            return await _authorServiceRepository.CreateAuthorWithCrossTable(createdEntity, tEntities.Data);
        }

        public async Task<GenericResponseDto<NoContent>> CreateEntity(GenericInputDto<CreateAuthorDto> tEntity)
        {
            Author author = _mapper.Map<Author>(tEntity.Data);
            await _genericAuthorCrudRepository.Insert(author);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> DeleteEntity(GenericInputDto<DeleteAuthorDto> tEntity)
        {
            await _genericAuthorCrudRepository.Delete((long)tEntity.Data.Id);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }

        public GenericResponseDto<List<AuthorDto>> GetAllEntity(GenericInputDto<NoContent> tEntity)
        {
            List<Author> authors = _genericAuthorCrudRepository.GetAll().ToList();
            return GenericResponseDto<List<AuthorDto>>.ResponseData(_mapper.Map<List<AuthorDto>>(authors), (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<AuthorDto>> GetByIdEntity(int id)
        {
            Author author = await _genericAuthorCrudRepository.GetById(id);
            return GenericResponseDto<AuthorDto>.ResponseData(_mapper.Map<AuthorDto>(author), (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> UpdateEntity(GenericInputDto<UpdateAuthorDto> tEntity)
        {
            Author author = _mapper.Map<Author>(tEntity.Data);
            await _genericAuthorCrudRepository.Update(author);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }
    }
}
