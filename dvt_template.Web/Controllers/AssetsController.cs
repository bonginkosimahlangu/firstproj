using Autofac;
using dvt_template.Feature.Asset.Command;
using dvt_template.Feature.Asset.Query;
using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dvt_template.Web.Controllers
{
    [Route("api/[controller]")]
    public class AssetsController : Controller
    {
        private static IMediator _mediator;
        public AssetsController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(GetAllAssetsQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(GetAssetByIdQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AddAssetCommand).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }

        [HttpGet]
        [Route("GetAllAssets")]
        public List<AssetViewModel> GetAllAssets()
        {
            return _mediator.Send(new GetAllAssetsQuery()).Result;
        }

        [HttpGet]
        [Route("GetAssetById/{id}")]
        public AssetViewModel GetAssetById(int id)
        {
            return _mediator.Send(new GetAssetByIdQuery { SerialNumber = id }).Result;
        }

        [HttpPost]
        [Route("AddAsset")]
        public void CreateAsset([FromBody] AssetViewModel asset)
        {
            _mediator.Send(new AddAssetCommand { Asset = asset });
        }

        [HttpPut]
        [Route("UpdateAsset")]
        public void UpdateAsset([FromBody] AssetViewModel asset)
        {
            //var assetOld = GetAssetById(id);
            //assetOld.SerialNumber = asset.SerialNumber;
            //assetOld.AssetModel = asset.AssetModel;
            //assetOld.AssetTypeId = asset.AssetTypeId;
            _mediator.Send(new UpdateAssetCommand { Asset = asset });
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _mediator.Send(new DeleteAssetCommand { SerialNumber = id });
        }
    }
}