using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using dvt_template.Shared.Core.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using dvt_template.Feature.ManageAsset;
using dvt_template.Feature.ManageAsset.Query;
using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Feature.ManageAsset.Command;

namespace dvt_template.Web.Controllers
{
    [Route("api/[controller]")]
    public class ManageAssetsController : Controller
    {
        private static IMediator _mediator;
        public ManageAssetsController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(GetManageAssetsQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(GetManageAssetByIdQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AddManageAssetCommand).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }

        [HttpGet]
        [Route("GetManageAssets")]
        public List<ManageAssetViewModel> GetAllAssets()
        {
            return _mediator.Send(new GetManageAssetsQuery()).Result;
        }

        [HttpGet]
        [Route("GetAssetById")]
        public ManageAssetViewModel GetAssetById(int id)
        {
            return _mediator.Send(new GetManageAssetByIdQuery { AllocationID = id }).Result;
        }

        [HttpPost]
        [Route("NewManageAsset")]
        public void CreateAsset([FromBody] ManageAssetViewModel manageasset)
        {
            _mediator.Send(new AddManageAssetCommand { ManageAsset = manageasset });
        }

        [HttpPut]
        [Route("ManageAsset")]
        public void ManageAsset([FromBody] ManageAssetViewModel manageasset)
        {
            _mediator.Send(new UpdateManageAssetCommand { ManageAssets = manageasset});
        }

        [HttpDelete]
        [Route("DeleteManageAsset")]
        public void DeleteManageAssset(int id)
        {
            _mediator.Send(new DeleteManageAssetCommand { ManageAsset = id });
        }

    }
}
