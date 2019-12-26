import { ImgFile } from './ImgFile';

export interface AddCarDto{
    brand: string;
    model: string;
    productionDate: Date;
    mileage: number;
    photoFile: ImgFile;
}