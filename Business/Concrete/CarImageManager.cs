using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public async Task<IResult> Add(IFormFile file)
        {
            try
            {
                var result = BusinessRules.Run(CheckFileFormat(file));

                // Resim verisini okuyun
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "Images", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                    var carImages = new CarImage
                    {
                        imagePath = filePath,
                        date = DateTime.Now
                    };
                    //_carImageService.Add();

                }
                // Başarılı yanıt döndür
                //_carImageDal.Add(entity);
                return new SuccessResult(Messages.CarImageAdded);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir yanıt döndür
                return new ErrorResult($"Resim yüklenirken bir hata oluştu: {ex.Message}");
            }
            
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            if (result is null)
            {
                return new ErrorDataResult<List<CarImage>>(result, Messages.Null);
            }
            return new SuccessDataResult<List<CarImage>>(result, Messages.CarImagesListed);
        }

        public IResult CheckFileFormat(IFormFile file)
        {
            if (file == null || file.Length == 0 || !file.ContentType.StartsWith("image"))
            {
                return new ErrorResult("Geçersiz veya eksik resim dosyası.");
            }
            return new SuccessResult();
        }
    }
}
