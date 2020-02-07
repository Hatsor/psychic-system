 public Result<PAProductTypesDTO> GetAvailableProductTypes()
        {
            var result = ExecuteRequest<PAGetAvailableProductTypesResponse>(PagaAquiAPIMethods.GetAvailableProductTypes, Method.POST, new PAGetAvailableProductTypesRequest()
            {
                Token = _token
            });

            if (!result.Success)
                return new Result<PAProductTypesDTO>(false, result.ErrorInfo);

            var validations = new List<(Func<PAGetAvailableProductTypesResponse, bool> func, Result error)>()
            {
               ((PAGetAvailableProductTypesResponse obj) => obj.AvailableProductTypeList == null, Results.PagaAqui_EmptyProductTypes)
            };

            return ValidateResponseBaseRequest(result, validations, (PAGetAvailableProductTypesResponse obj) => _mapper.Map<PAProductTypesDTO>(obj));
        }

        private Result<T2> ValidateResponseBaseRequest<T, T2>(Result<T> result, List<(Func<T, bool> func, Result error)> validations, Func<T, T2> mapFunc) where T : PABaseResponse
        {
            if ((!result.Obj.OperationSucceeded ?? false))
                return Results.PagaAqui_FailedOperation;

            foreach (var validation in validations)
                if (validation.func(result.Obj))
                    return validation.error;

            return new Result<T2>(mapFunc(result.Obj));
        }

        