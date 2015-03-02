using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class ItemClientFixture : BaseClientFixture<ItemClient>
    {
        #region Arrange

        #region validAPIResponseForGetAsync
        const string validAPIResponseForGetAsync = @"{
            'Data': {
                'Item': {
                    'DynamicAttributes': [
                        {
                            'TypeId': 1,
                            'TypeValueId': 1,
                            'Value': 'Red',
                            'TypeName': 'Color'
                        },
                        {
                            'TypeId': 3,
                            'TypeValueId': 7,
                            'Value': 'A',
                            'TypeName': 'Style'
                        },
                        {
                            'TypeId': 2,
                            'TypeValueId': 9,
                            'Value': 'S',
                            'TypeName': 'Size'
                        }
                    ],
                    'Id': 1,
                    'RFID': null,
                    'UUID': null,
                    'SKU': null,
                    'Name': 'D1Red-S-AStyle',
                    'Model': 'Model1',
                    'Title': 'D1Title',
                    'ShortDescription': 'MasterItem1ShortDescription',
                    'LongDescription': null,
                    'Rating': null,
                    'LikeCount': 80,
                    'CategoryId': 66,
                    'InStock': true,
                    'PublicWebLink': null,
                    'DefaultItemId': 1,
                    'BrandId': 1,
                    'UnitTypeId': 3,
                    'UnitTypeName': 'Quantity',
                    'UnitTypeCode': 'Quantity',
                    'Prices': [
                        {
                            'NormalPrice': 140.55,
                            'DiscountPrice': null,
                            'PriceTypeSymbol': '$',
                            'PriceTypeId': 1
                        }
                    ],
                    'Tags': [
                        {
                            'Id': 2,
                            'Name': 'SampleTag1',
                            'Description': '3e129d70-2308-4dc5-bd33-c389b92859d2'
                        }
                    ],
                    'Weights': [
                        {
                            'WeightTypeId': 1,
                            'WeightTypeDescription': 'Kg',
                            'Value': 20
                        },
                        {
                            'WeightTypeId': 2,
                            'WeightTypeDescription': 'LBS',
                            'Value': 40
                        }
                    ],
                    'Dimensions': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionDescription': 'Meter',
                            'Width': 1,
                            'Height': 1,
                            'Depth': 1
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionDescription': 'Inch',
                            'Width': 3,
                            'Height': 3,
                            'Depth': 3
                        }
                    ],
                    'Metadata': [
                        {
                            'Key': 'Key1',
                            'Value': '291b4f13-0881-4228-92f4-7bcef85a7fc0'
                        }
                    ],
                    'InStoreMetadata': [
                        {
                            'Key': 'Key1',
                            'Value': '291b4f13-0881-4228-92f4-7bcef85a7fc0'
                        }
                    ],
                    'ImageAssets': [
                        {
                            'ResizedAssets': [
                                {
                                    'ImageSizeProfile': {
                                        'Id': 1,
                                        'Height': 300,
                                        'Width': 500
                                    },
                                    'AssetUrl': '6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                },
                                {
                                    'ImageSizeProfile': {
                                        'Id': 2,
                                        'Height': 600,
                                        'Width': 1000
                                    },
                                    'AssetUrl': '6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                },
                                {
                                    'ImageSizeProfile': {
                                        'Id': 3,
                                        'Height': 900,
                                        'Width': 1500
                                    },
                                    'AssetUrl': '6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
                                }
                            ],
                            'AssetMetadata': [
                                {
                                    'Key': '3a692756-4767-4160-b35c-29859468160f',
                                    'Value': '60dd4bee-eee3-4cd3-a18d-f695fffb0b1a'
                                },
                                {
                                    'Key': 'de8ac384-04b3-4588-ae28-d69fbb12ace7',
                                    'Value': 'ca9f2cd5-1662-41fd-8d6d-bd893ea02fae'
                                },
                                {
                                    'Key': 'fa7548ff-94e7-419d-bd52-5376eeb7279e',
                                    'Value': '21d6e55a-cc96-4d1d-bf51-43c3915a2ad5'
                                }
                            ],
                            'AssetId': 1,
                            'AssetUrl': 'http: //127.0.0.1: 10000/5e2dd075-957f-4884-8992-030d1eabcc79',
                            'IsDefault': true
                        }
                    ],
                    'VideoAssets': [
                        {
                            'AssetMetadata': [
                                {
                                    'Key': '34824e92-bb05-4d52-841e-5a5567866bee',
                                    'Value': '7fa6bbd4-f9ff-4715-b1d9-f82329a481b7'
                                },
                                {
                                    'Key': 'd90611bd-eae7-4be5-83fd-d92dcee485a8',
                                    'Value': '05a8e069-372a-4695-aae4-de7a58c94b3b'
                                },
                                {
                                    'Key': '0d083335-e54d-4f22-8898-596168f23bd7',
                                    'Value': '27997259-69f2-41cf-bacb-07950c040231'
                                }
                            ],
                            'AssetId': 2,
                            'AssetUrl': 'http: //127.0.0.1: 10000/ac3adc70-3394-4da7-8dfd-19a8e0edb373',
                            'IsDefault': false
                        }
                    ],
                    'DocumentAssets': [
                        {
                            'AssetMetadata': [
                                {
                                    'Key': 'c804de73-a2cc-48ec-ae51-8ead84251471',
                                    'Value': 'd5fefcbb-3912-4a0c-8f62-a0db9d22dca5'
                                },
                                {
                                    'Key': 'e80dcbd6-f340-49fe-9817-23e3749e51d4',
                                    'Value': '41def150-a42d-478a-9915-ee5e748fb282'
                                },
                                {
                                    'Key': 'f7d26397-a681-45a3-bd47-d7825cde12ea',
                                    'Value': 'f817cb15-a7ed-4174-8030-4f534f1a3746'
                                }
                            ],
                            'AssetId': 3,
                            'AssetUrl': 'http: //127.0.0.1: 10000/e4521bbe-6cd0-419a-ab90-73c5f06a6252',
                            'IsDefault': true
                        }
                    ]
                },
                'DynamicNavigation': [
                    {
                        'TypeId': 1,
                        'TypeValueId': 1,
                        'Value': 'Red',
                        'TypeName': 'Color'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 4,
                        'Value': 'M',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 6,
                        'Value': 'XL',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 9,
                        'Value': 'S',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 10,
                        'Value': 'XXXXXXXXL',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 7,
                        'Value': 'A',
                        'TypeName': 'Style'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 11,
                        'Value': 'AStyle',
                        'TypeName': 'Style'
                    }
                ],
                'StaticNavigation': {
                    'Categories': [
                        {
                            'Id': 1,
                            'Name': 'SampleCategory0',
                            'ShortDescription': '3b6fc358-d3b4-4da5-b617-3e17e78c8ddc',
                            'LongDescription': '1ae0428e-bc59-4119-90c1-2b9d3a042c5b',
                            'SubCategoryCount': 0,
                            'CategoryMetadata': [],
                            'ParentCategoryId': null,
                            'ParentCategoryName': ''
                        },
                        {
                            'Id': 66,
                            'Name': 'Category1Sub1Sub1',
                            'ShortDescription': 'Category1Sub1Sub1ShortDescription',
                            'LongDescription': 'Category1Sub1Sub1LongDescription',
                            'SubCategoryCount': 0,
                            'CategoryMetadata': [],
                            'ParentCategoryId': 62,
                            'ParentCategoryName': 'Category1Sub1'
                        }
                    ],
                    'Brands': [
                        {
                            'Id': 1,
                            'Name': 'Brand1'
                        },
                        {
                            'Id': 4,
                            'Name': 'Brand4'
                        }
                    ],
                    'Tags': [
                        {
                            'Id': 1,
                            'Name': 'SampleTag0',
                            'Description': 'dfd407fb-1995-4cfc-88e1-5dce73577bec',
                            'TagMetadata': []
                        },
                        {
                            'Id': 2,
                            'Name': 'SampleTag1',
                            'Description': '870e1a32-cf43-4ef2-932f-0a2d199ff108',
                            'TagMetadata': []
                        },
                        {
                            'Id': 3,
                            'Name': 'SampleTag2',
                            'Description': 'cb59c090-761b-47ff-9aee-9199ec746409',
                            'TagMetadata': []
                        }
                    ],
                    'Currencies': [
                        {
                            'Id': 1,
                            'Description': 'USD',
                            'PriceTypeSymbol': '$'
                        },
                        {
                            'Id': 2,
                            'Description': 'Euro',
                            'PriceTypeSymbol': '€'
                        }
                    ],
                    'UnitTypes': [
                        {
                            'Id': 1,
                            'Name': '100Gram',
                            'Description': '100Gram',
                            'UnitCode': 'Gr'
                        },
                        {
                            'Id': 3,
                            'Name': 'Quantity',
                            'Description': 'Quantity',
                            'UnitCode': 'Quantity'
                        }
                    ],
                    'WidthRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 1,
                            'Max': 60
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 3,
                            'Max': 30
                        }
                    ],
                    'HeightRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 1,
                            'Max': 70
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 3,
                            'Max': 40
                        }
                    ],
                    'DepthRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 1,
                            'Max': 50
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 3,
                            'Max': 20
                        }
                    ],
                    'WeightRanges': [
                        {
                            'WeightTypeId': 1,
                            'WeightTypeDescription': 'Kg',
                            'Min': 15,
                            'Max': 15
                        },
                        {
                            'WeightTypeId': 2,
                            'WeightTypeDescription': 'LBS',
                            'Min': 25,
                            'Max': 25
                        }
                    ],
                    'PriceRanges': [
                        {
                            'PriceTypeId': 1,
                            'PriceTypeSymbol': '$',
                            'Min': 50,
                            'Max': 160.55
                        }
                    ],
                    'DiscountPriceRanges': [
                        {
                            'PriceTypeId': 1,
                            'PriceTypeSymbol': '$',
                            'Min': 50,
                            'Max': 50
                        }
                    ]
                }
            }
        }";
        #endregion

        #region validAPIResponseForGetSearchOptions
        const string validAPIResponseForGetSearchOptions = @"{
            'Data': {
                'SearchRequest': {
                    'Skip': 0,
                    'Take': 10,
                    'OrderedPropertyName': null,
                    'OrderBy': null,
                    'IncludeStaticNavigation': true,
                    'IncludeDynamicNavigation': true,
                    'DefaultItemId': null,
                    'RFID': null,
                    'UUID': null,
                    'Name': null,
                    'SKU': null,
                    'CategoryId': null,
                    'BrandId': null,
                    'Model': null,
                    'Title': null,
                    'MinWidth': null,
                    'MaxWidth': null,
                    'MinHeight': null,
                    'MaxHeight': null,
                    'MinWeigth': null,
                    'MaxWeigth': null,
                    'MinDepth': null,
                    'MaxDepth': null,
                    'MinPrice': null,
                    'MaxPrice': null,
                    'DimensionTypeId': null,
                    'WeightTypeId': null,
                    'TagId': null,
                    'DelimitedDynamicAttributeValues': '1:1;',
                    'IncludeOnlyMasterItems': false
                },
                'SearchResult': {
                    'Items': [
                        {
                            'Id': 7,
                            'RFID': null,
                            'UUID': null,
                            'SKU': null,
                            'Name': 'D2 Red-S-A Style',
                            'Model': 'Model 2',
                            'Title': 'D2 Title',
                            'ShortDescription': 'D2 Short Description',
                            'LongDescription': 'D2 Long Description',
                            'Rating': null,
                            'LikeCount': 80,
                            'CategoryId': 67,
                            'InStock': true,
                            'PublicWebLink': null,
                            'DefaultItemId': 2,
                            'BrandId': 2,
                            'UnitTypeId': 3,
                            'UnitTypeCode': 'Quantity',
                            'UnitTypeName': 'Quantity',
                            'DynamicAttributes': [
                                {
                                    'TypeId': 2,
                                    'TypeValueId': 5,
                                    'Value': 'L',
                                    'TypeName': 'Size'
                                },
                                {
                                    'TypeId': 3,
                                    'TypeValueId': 8,
                                    'Value': 'B',
                                    'TypeName': 'Style'
                                }
                            ],
                            'Prices': [
                                {
                                    'NormalPrice': 140.55,
                                    'DiscountPrice': 50,
                                    'CurrencySymbol': '$',
                                    'CurrencyId': 1
                                }
                            ],
                            'Tags': [],
                            'Weights': [
                                {
                                    'WeightTypeId': 1,
                                    'WeightTypeDescription': 'Kg',
                                    'Value': 20
                                },
                                {
                                    'WeightTypeId': 2,
                                    'WeightTypeDescription': 'LBS',
                                    'Value': 40
                                }
                            ],
                            'Dimensions': [
                                {
                                    'DimensionTypeId': 1,
                                    'DimensionDescription': 'Meter',
                                    'Width': 11,
                                    'Height': 11,
                                    'Depth': 11
                                },
                                {
                                    'DimensionTypeId': 2,
                                    'DimensionDescription': 'Inch',
                                    'Width': 5,
                                    'Height': 5,
                                    'Depth': 5
                                }
                            ],
                            'Metadata': [],
                            'ImageAssets': [
                                {
        'ResizedAssets':[
           {
               'CreatedDate':'2013-10-04T10:39:50.027',
               'ImageSizeProfile':{
                   'Id':1,
                   'Height':300,
                   'Width':500
               },
               'AssetUrl':'6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
           },
           {
               'CreatedDate':'2013-10-04T10:39:50.027',
               'ImageSizeProfile':{
                   'Id':2,
                   'Height':600,
                   'Width':1000
               },
               'AssetUrl':'6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
           },
           {
               'CreatedDate':'2013-10-04T10:39:50.027',
               'ImageSizeProfile':{
                   'Id':3,
                   'Height':900,
                   'Width':1500
               },
               'AssetUrl':'6D16EE1F-73A1-4BB0-9BAA-8FD27C0B3568'
           }
        ],
                                    'AssetMetadata': [
                                        {
                                            'Key': '3a692756-4767-4160-b35c-29859468160f',
                                            'Value': '60dd4bee-eee3-4cd3-a18d-f695fffb0b1a'
                                        },
                                        {
                                            'Key': 'de8ac384-04b3-4588-ae28-d69fbb12ace7',
                                            'Value': 'ca9f2cd5-1662-41fd-8d6d-bd893ea02fae'
                                        },
                                        {
                                            'Key': 'fa7548ff-94e7-419d-bd52-5376eeb7279e',
                                            'Value': '21d6e55a-cc96-4d1d-bf51-43c3915a2ad5'
                                        }
                                    ],
                                    'AssetId': 1,
                                    'AssetUrl': 'http://127.0.0.1:10000/5e2dd075-957f-4884-8992-030d1eabcc79',
                                    'IsDefault': true
                                }
                            ],
                            'ImageAssets': [
                                {
                                    'AssetMetadata': [
                                        {
                                            'Key': '3a692756-4767-4160-b35c-29859468160f',
                                            'Value': '60dd4bee-eee3-4cd3-a18d-f695fffb0b1a'
                                        },
                                        {
                                            'Key': 'de8ac384-04b3-4588-ae28-d69fbb12ace7',
                                            'Value': 'ca9f2cd5-1662-41fd-8d6d-bd893ea02fae'
                                        },
                                        {
                                            'Key': 'fa7548ff-94e7-419d-bd52-5376eeb7279e',
                                            'Value': '21d6e55a-cc96-4d1d-bf51-43c3915a2ad5'
                                        }
                                    ],
                                    'AssetId': 1,
                                    'AssetUrl': 'http://127.0.0.1:10000/5e2dd075-957f-4884-8992-030d1eabcc79',
                                    'IsDefault': true,
		               'ResizedAssets':[
              		        {
		                          'ImageSizeProfile':{
                     				         'Id':1,
				                              'Height':100,
				                              'Width':200
                  				              },
                                               'AssetUrl':'http://xomnistaging.blob.core.windows.net/resizedassets/test-resizedasset'
              		        }
           	              ],
                                }
                            ],
                            'VideoAssets': [
                                {
                                    'AssetMetadata': [
                                        {
                                            'Key': '34824e92-bb05-4d52-841e-5a5567866bee',
                                            'Value': '7fa6bbd4-f9ff-4715-b1d9-f82329a481b7'
                                        },
                                        {
                                            'Key': 'd90611bd-eae7-4be5-83fd-d92dcee485a8',
                                            'Value': '05a8e069-372a-4695-aae4-de7a58c94b3b'
                                        },
                                        {
                                            'Key': '0d083335-e54d-4f22-8898-596168f23bd7',
                                            'Value': '27997259-69f2-41cf-bacb-07950c040231'
                                        }
                                    ],
                                    'AssetId': 2,
                                    'AssetUrl': 'http://127.0.0.1:10000/ac3adc70-3394-4da7-8dfd-19a8e0edb373',
                                    'IsDefault': false,  		       
                                }
                            ],
                            'DocumentAssets': [
                                {
                                    'AssetMetadata': [
                                        {
                                            'Key': 'c804de73-a2cc-48ec-ae51-8ead84251471',
                                            'Value': 'd5fefcbb-3912-4a0c-8f62-a0db9d22dca5'
                                        },
                                        {
                                            'Key': 'e80dcbd6-f340-49fe-9817-23e3749e51d4',
                                            'Value': '41def150-a42d-478a-9915-ee5e748fb282'
                                        },
                                        {
                                            'Key': 'f7d26397-a681-45a3-bd47-d7825cde12ea',
                                            'Value': 'f817cb15-a7ed-4174-8030-4f534f1a3746'
                                        }
                                    ],
                                    'AssetId': 3,
                                    'AssetUrl': 'http://127.0.0.1:10000/e4521bbe-6cd0-419a-ab90-73c5f06a6252',
                                    'IsDefault': true
                                }
                            ]
                        },
                        {
                            'Id': 8,
                            'RFID': null,
                            'UUID': null,
                            'SKU': null,
                            'Name': 'D2 Red-S-A Style',
                            'Model': 'Model 2',
                            'Title': 'D2 Title',
                            'ShortDescription': 'D2 Short Description',
                            'LongDescription': 'D2 Long Description',
                            'Rating': null,
                            'LikeCount': 80,
                            'CategoryId': 67,
                            'InStock': true,
                            'PublicWebLink': null,
                            'DefaultItemId': 2,
                            'BrandId': 2,
                            'UnitTypeId': 3,
                            'UnitTypeCode': 'Quantity',
                            'UnitTypeName': 'Quantity',
                            'DynamicAttributes': [
                                {
                                    'TypeId': 2,
                                    'TypeValueId': 5,
                                    'Value': 'L',
                                    'TypeName': 'Size'
                                },
                                {
                                    'TypeId': 3,
                                    'TypeValueId': 8,
                                    'Value': 'B',
                                    'TypeName': 'Style'
                                }
                            ],
                            'Prices': [
                                {
                                    'NormalPrice': 140.55,
                                    'DiscountPrice': 50,
                                    'PriceTypeSymbol': '$',
                                    'PriceTypeId': 1
                                }
                            ],
                            'Tags': [],
                            'Weights': [],
                            'Dimensions': [
                                {
                                    'DimensionTypeId': 1,
                                    'DimensionDescription': 'Meter',
                                    'Width': 11,
                                    'Height': 11,
                                    'Depth': 11
                                },
                                {
                                    'DimensionTypeId': 2,
                                    'DimensionDescription': 'Inch',
                                    'Width': 5,
                                    'Height': 5,
                                    'Depth': 5
                                }
                            ],
                            'Metadata': [],
                            'ImageAssets': [],
                            'VideoAssets': [],
                            'DocumentAssets': []
                        }
                    ],
                    'TotalItemCount': 2,
                    'DynamicNavigation': [
                        {
                            'TypeId': 1,
                            'TypeValueId': 1,
                            'Value': 'Red',
                            'TypeName': 'Color'
                        },
                        {
                            'TypeId': 2,
                            'TypeValueId': 4,
                            'Value': 'M',
                            'TypeName': 'Size'
                        },
                        {
                            'TypeId': 2,
                            'TypeValueId': 5,
                            'Value': 'L',
                            'TypeName': 'Size'
                        },
                        {
                            'TypeId': 2,
                            'TypeValueId': 6,
                            'Value': 'XL',
                            'TypeName': 'Size'
                        },
                        {
                            'TypeId': 3,
                            'TypeValueId': 7,
                            'Value': 'A',
                            'TypeName': 'Style'
                        },
                        {
                            'TypeId': 3,
                            'TypeValueId': 8,
                            'Value': 'B',
                            'TypeName': 'Style'
                        },
                        {
                            'TypeId': 2,
                            'TypeValueId': 9,
                            'Value': 'S',
                            'TypeName': 'Size'
                        }
                    ],
                    'StaticNavigation': {
                        'Categories': [
                            {
                                'Id': 66,
                                'Name': 'Category 1 Sub 1 Sub 1',
                                'ShortDescription': 'Category 1 Sub 1 Sub 1 Short Description',
                                'LongDescription': 'Category 1 Sub 1 Sub 1 Long Description',
                                'SubCategoryCount': 0,
                                'ParentCategoryId': 62,
                                'ParentCategoryName': 'Category 1 Sub 1'
                            },
                            {
                                'Id': 67,
                                'Name': 'Category 1 Sub 1 Sub 2',
                                'ShortDescription': 'Category 1 Sub 1 Sub 1 Short Description',
                                'LongDescription': 'Category 1 Sub 1 Sub 1 Long Description',
                                'SubCategoryCount': 0,
                                'ParentCategoryId': 62,
                                'ParentCategoryName': 'Category 1 Sub 1'
                            }
                        ],
                        'Brands': [
                            {
                                'Id': 1,
                                'Name': 'Brand 1'
                            },
                            {
                                'Id': 2,
                                'Name': 'Brand 2'
                            }
                        ],
                        'Tags': [
                            {
                                'Id': 2,
                                'Name': 'Sample Tag 1',
                                'Description': '3e129d70-2308-4dc5-bd33-c389b92859d2'
                            }
                        ],
                        'PriceTypes': [
                            {
                                'Id': 1,
                                'Description': 'USD',
                                'PriceTypeSymbol': '$'
                            },
                            {
                                'Id': 2,
                                'Description': 'Euro',
                                'PriceTypeSymbol': '€'
                            }
                        ],
                        'UnitTypes': [
                            {
                                'Id': 2,
                                'Name': '250 Kilogram',
                                'Description': '1 Kilogram',
                                'UnitCode': 'Kg'
                            },
                            {
                                'Id': 3,
                                'Name': 'Quantity',
                                'Description': 'Quantity',
                                'UnitCode': 'Quantity'
                            }
                        ],
                        'WidthRanges': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionTypeDescription': 'Meter',
                                'Min': 11,
                                'Max': 11
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionTypeDescription': 'Inch',
                                'Min': 5,
                                'Max': 5
                            }
                        ],
                        'HeightRanges': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionTypeDescription': 'Meter',
                                'Min': 11,
                                'Max': 11
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionTypeDescription': 'Inch',
                                'Min': 5,
                                'Max': 5
                            }
                        ],
                        'DepthRanges': [
                            {
                                'DimensionTypeId': 1,
                                'DimensionTypeDescription': 'Meter',
                                'Min': 11,
                                'Max': 11
                            },
                            {
                                'DimensionTypeId': 2,
                                'DimensionTypeDescription': 'Inch',
                                'Min': 5,
                                'Max': 5
                            }
                        ],
                        'WeightRanges': [],
                        'PriceRanges': [
                            {
                                'PriceTypeId': 1,
                                'PriceTypeSymbol': '$',
                                'Min': 10.55,
                                'Max': 8888
                            }
                        ],
                        'DiscountPriceRanges': [
                            {
                                'PriceTypeId': 1,
                                'PriceTypeSymbol': '$',
                                'Min': 50,
                                'Max': 888
                            }
                        ]
                    }
                }
            }
        }";
        #endregion

        #region validAPIResponseForSearch
        const string validAPIResponseForSearch = @"{
            'Data': {
                'DynamicNavigation': [
                    {
                        'TypeId': 1,
                        'TypeValueId': 1,
                        'Value': 'Red',
                        'TypeName': 'Color'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 4,
                        'Value': 'M',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 5,
                        'Value': 'L',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 6,
                        'Value': 'XL',
                        'TypeName': 'Size'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 7,
                        'Value': 'A',
                        'TypeName': 'Style'
                    },
                    {
                        'TypeId': 3,
                        'TypeValueId': 8,
                        'Value': 'B',
                        'TypeName': 'Style'
                    },
                    {
                        'TypeId': 2,
                        'TypeValueId': 9,
                        'Value': 'S',
                        'TypeName': 'Size'
                    }
                ],
                'StaticNavigation': {
                    'Categories': [
                        {
                            'Id': 66,
                            'Name': 'Category 1 Sub 1 Sub 1',
                            'ShortDescription': 'Category 1 Sub 1 Sub 1 Short Description',
                            'LongDescription': 'Category 1 Sub 1 Sub 1 Long Description',
                            'SubCategoryCount': 0,
                            'ParentCategoryId': 62,
                            'ParentCategoryName': 'Category 1 Sub 1'
                        },
                        {
                            'Id': 67,
                            'Name': 'Category 1 Sub 1 Sub 2',
                            'ShortDescription': 'Category 1 Sub 1 Sub 1 Short Description',
                            'LongDescription': 'Category 1 Sub 1 Sub 1 Long Description',
                            'SubCategoryCount': 0,
                            'ParentCategoryId': 62,
                            'ParentCategoryName': 'Category 1 Sub 1'
                        }
                    ],
                    'Brands': [
                        {
                            'Id': 1,
                            'Name': 'Brand 1'
                        },
                        {
                            'Id': 2,
                            'Name': 'Brand 2'
                        }
                    ],
                    'Tags': [
                        {
                            'Id': 2,
                            'Name': 'Sample Tag 1',
                            'Description': '3e129d70-2308-4dc5-bd33-c389b92859d2'
                        }
                    ],
                    'Currencies': [
                        {
                            'Id': 1,
                            'Description': 'USD',
                            'CurrencySymbol': '$'
                        },
                        {
                            'Id': 2,
                            'Description': 'Euro',
                            'CurrencySymbol': '€'
                        }
                    ],
                    'UnitTypes': [
                        {
                            'Id': 2,
                            'Name': '250 Kilogram',
                            'Description': '1 Kilogram',
                            'UnitCode': 'Kg'
                        },
                        {
                            'Id': 3,
                            'Name': 'Quantity',
                            'Description': 'Quantity',
                            'UnitCode': 'Quantity'
                        }
                    ],
                    'WidthRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 11,
                            'Max': 11
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 5,
                            'Max': 5
                        }
                    ],
                    'HeightRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 11,
                            'Max': 11
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 5,
                            'Max': 5
                        }
                    ],
                    'DepthRanges': [
                        {
                            'DimensionTypeId': 1,
                            'DimensionTypeDescription': 'Meter',
                            'Min': 11,
                            'Max': 11
                        },
                        {
                            'DimensionTypeId': 2,
                            'DimensionTypeDescription': 'Inch',
                            'Min': 5,
                            'Max': 5
                        }
                    ],
                    'WeightRanges': [],
                    'PriceRanges': [
                        {
                            'CurrencyId': 1,
                            'CurrencySymbol': '$',
                            'Min': 10.55,
                            'Max': 8888
                        }
                    ],
                    'DiscountPriceRanges': [
                        {
                            'CurrencyId': 1,
                            'CurrencySymbol': '$',
                            'Min': 50,
                            'Max': 888
                        }
                    ]
                }
            }
        }";

        #endregion

        #region validAPIRequestForGetSearchOptions
        const string validAPIRequestForGetSearchOptions = @"{
            'Skip':0,
            'Take':10,
            'OrderedPropertyName':null,
            'OrderBy':null,
            'IncludeStaticNavigation':true,
            'IncludeDynamicNavigation':true,
            'DefaultItemId':null,
            'RFID':null,
            'UUID':null,
            'Name':null,
            'SKU':null,
            'CategoryId':null,
            'BrandId':null,
            'Model':null,
            'Title':null,
            'MinWidth':null,
            'MaxWidth':null,
            'MinHeight':null,
            'MaxHeight':null,
            'MinWeigth':null,
            'MaxWeigth':null,
            'MinDepth':null,
            'MaxDepth':null,
            'MinPrice':null,
            'MaxPrice':null,
            'DimensionTypeId':null,
            'WeightTypeId':null,
            'TagId':null,
            'DelimitedDynamicAttributeValues':'1:1;',
            'IncludeOnlyMasterItems':false,
            'IncludeItemStaticProperties':true,
            'IncludeItemDynamicProperties':true,
            'ImageAssetDetail':4,
            'VideoAssetDetail':4,
            'DocumentAssetDetail':4,
            'TagQuery':null,
            'ItemIds':[
	           1,
	           2,
	           3
	        ]
        }";
        #endregion

        #region validAPIRequestForSearch

        const string validAPIRequestForSearch = @"{
            'Skip':0,
            'Take':10,
            'OrderedPropertyName':'Title',
            'OrderBy':'Asc',
            'IncludeStaticNavigation':true,
            'IncludeDynamicNavigation':true,
            'DefaultItemId':null,
            'RFID':null,
            'UUID':null,
            'Name':null,
            'SKU':null,
            'CategoryId':null,
            'BrandId':null,
            'Model':null,
            'Title':null,
            'MinWidth':null,
            'MaxWidth':null,
            'MinHeight':null,
            'MaxHeight':null,
            'MinWeigth':null,
            'MaxWeigth':null,
            'MinDepth':null,
            'MaxDepth':null,
            'MinPrice':null,
            'MaxPrice':null,
            'DimensionTypeId':null,
            'WeightTypeId':null,
            'TagId':null,
            'DelimitedDynamicAttributeValues':'1:1',
            'IncludeOnlyMasterItems':false,
            'IncludeItemStaticProperties':true,
            'IncludeItemDynamicProperties':true,
            'ImageAssetDetail':4,
            'VideoAssetDetail':4,
            'DocumentAssetDetail':4,
            'TagQuery':null,
            'ItemIds':[
	           1,
	           2,
	           3
	        ]
        }";
        #endregion

        #region validAPIRequestForSearchOption

        const string validAPIRequestForSearchOption = @"{
            'DefaultItemId':null,
            'RFID':null,
            'UUID':null,
            'Name':null,
            'SKU':null,
            'CategoryId':66,
            'BrandId':null,
            'Model':null,
            'Title':null,
            'MinWidth':null,
            'MaxWidth':null,
            'MinHeight':null,
            'MaxHeight':null,
            'MinWeight':null,
            'MaxWeight':null,
            'MinDepth':null,
            'MaxDepth':null,
            'MinPrice':null,
            'MaxPrice':null,
            'DimensionTypeId':null,
            'WeightTypeId':null,
            'TagId':null,
            'DelimitedDynamicAttributeValues':null,
            'IncludeOnlyMasterItems':false,
            'TagQuery':null   
        }";

        #endregion

        readonly ItemSearchRequest sampleItemSearchRequest = new ItemSearchRequest()
        {
            Skip = 0,
            Take = 10,
            OrderedPropertyName = OrderedProperty.Title,
            OrderBy = OrderByType.Asc,
            DefaultItemId = null,
            RFID = null,
            Name = null,
            SKU = null,
            CategoryId = null,
            BrandId = null,
            Model = null,
            Title = null,
            MinWidth = null,
            MaxWidth = null,
            MinHeight = null,
            MaxHeight = null,
            MinDepth = null,
            MaxDepth = null,
            MinPrice = null,
            MaxPrice = null,
            DimensionTypeId = null,
            TagId = null,
            DelimitedDynamicAttributeValues = "1:1",
            IncludeOnlyMasterItems = false,
            ItemIds = new List<int>()
            {
                1,2,3
            }
        };

        readonly ItemSearchOptionsRequest sampleItemSearchOptionsRequest = new ItemSearchOptionsRequest()
        {
            Take = 1,
            DefaultItemId = null,
            RFID = null,
            UUID = null,
            Name = null,
            SKU = null,
            CategoryId = null,
            BrandId = null,
            Model = null,
            Title = null,
            MinWidth = null,
            MaxWidth = null,
            MinWeight = null,
            MaxWeight = null,
            MinHeight = null,
            MaxHeight = null,
            MinDepth = null,
            MaxDepth = null,
            MinPrice = null,
            MaxPrice = null,
            DimensionTypeId = null,
            WeightTypeId = null,
            TagId = null,
            DelimitedDynamicAttributeValues = null,
            IncludeOnlyMasterItems = false,
            TagQuery = null
        };

        #endregion

        #region GetAsync
        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemClient c) => c.GetAsync(1),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetAsync)
                },
                validAPIResponseForGetAsync
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemClient c) => c.GetAsync(1),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemClient c) => c.GetAsync(1),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, true, true, 0, 0, 0, false));

            await base.UriTestAsync(
                (ItemClient c) => c.GetAsync(1, includeItemInStoreMetadata: true),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, true, true, 0, 0, 0, true));

            await base.UriTestAsync(
                (ItemClient c) => c.GetAsync(1, includeItemStaticProperties: false),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, false, true, 0, 0, 0, false));

            await base.UriTestAsync(
                (ItemClient c) => c.GetAsync(1, includeItemDynamicProperties: false),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, true, false, 0, 0, 0, false));

            await base.UriTestAsync(
                (ItemClient c) => c.GetAsync(1, includeItemInStoreMetadata: true, includeItemStaticProperties: false, includeItemDynamicProperties: false),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, false, false, 0, 0, 0, true));

            await base.UriTestAsync(
                (ItemClient c) => c.GetAsync(1, imageAssetDetail: AssetDetailType.IncludeAll, videoAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, documentAssetDetail: AssetDetailType.IncludeOnlyDefault),
              string.Format("/catalog/item/{0}?includeItemStaticProperties={1}&includeItemDynamicProperties={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}&includeItemInStoreMetadata={6}", 1, true, true, 2, 4, 1, false));

        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ItemClient c) => c.GetAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.GetAsync(-1),
                new ArgumentException("id must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemClient c) => c.GetAsync(1)
            );
        }
        #endregion

        #region Search
        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemClient c) => c.Search(sampleItemSearchRequest, false),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForSearch)
                },
                validAPIResponseForSearch
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchRequestParseTest()
        {
            await base.RequestParseTestAsync<ItemSearchRequest>(
                (ItemClient c) => c.Search(sampleItemSearchRequest, false), validAPIRequestForSearch
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemClient c) => c.Search(sampleItemSearchRequest, false),
                HttpMethod.Post);
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemClient c) => c.Search(sampleItemSearchRequest, true),
              string.Format("/catalog/items?includeItemInStoreMetadata={0}", true));
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (ItemClient c) => c.Search(sampleItemSearchRequest, false),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
               (ItemClient c) => c.Search(null, false),
               new ArgumentNullException("itemSearchRequest can not be null."));

            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.Search(new ItemSearchRequest()
                {
                    Skip = -1,
                    Take = 4,
                    DelimitedDynamicAttributeValues = "1;1"
                }, false),
                new ArgumentException("Skip must be greater than or equal to 0."));

            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.Search(new ItemSearchRequest()
                {
                    Skip = 1,
                    Take = 4,
                    DelimitedDynamicAttributeValues = "1:1;"
                }, false),
                new ArgumentException("Given string format is not correct."));

            await base.SDKExceptionResponseTestAsync(
               (ItemClient c) => c.Search(new ItemSearchRequest()
               {
                   Skip = 1,
                   Take = -6,
                   DelimitedDynamicAttributeValues = "1;1"
               }, false),
               new ArgumentOutOfRangeException("Take", -6, string.Format("{0} must be in range ({1} - {2}).", "Take", 1, 1000)));

            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.Search(new ItemSearchRequest()
                {
                    Take = 1,
                    MinWeight = 300,
                    MaxWeight = 400,
                    DelimitedDynamicAttributeValues = "1:1"
                }),
                new ArgumentNullException("WeightTypeId can not be null.")
            );

            await base.SDKExceptionResponseTestAsync(
              (ItemClient c) => c.Search(new ItemSearchRequest()
              {
                  Take = 1,
                  MinWidth = 300,
                  MinHeight = 300,
                  MinDepth = 400,
                  DelimitedDynamicAttributeValues = "1:1"
              }),
              new ArgumentNullException("DimensionTypeId can not be null."));

            await base.SDKExceptionResponseTestAsync(
              (ItemClient c) => c.Search(new ItemSearchRequest()
              {
                  Take = 1,
                  MinWidth = 300,
                  MaxWidth = 220,
              }),
              new ArgumentException(string.Format("{0} can not be greater than {1}.", "MinWidth", "MaxWidth")));
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("Search"), TestCategory("HTTP.POST")]
        public async Task SearchHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemClient c) => c.Search(sampleItemSearchRequest, false)
            );
        }
        #endregion

        #region GetSearchOptions

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ItemClient c) => c.GetSearchOptions(sampleItemSearchOptionsRequest),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetSearchOptions)
                },
                validAPIResponseForGetSearchOptions);
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ItemClient c) => c.GetSearchOptions(sampleItemSearchOptionsRequest),
                HttpMethod.Post);
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsUriCheckTest()
        {
            await base.UriTestAsync(
              (ItemClient c) => c.GetSearchOptions(sampleItemSearchOptionsRequest),
              "/catalog/itemsearchoptions");
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.GetSearchOptions(null),
                new ArgumentNullException("itemSearchOptionsRequest can not be null.")
            );

            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.GetSearchOptions(new ItemSearchOptionsRequest()
                {
                    Skip = -1,
                    Take = 4,
                    DelimitedDynamicAttributeValues = "1:1"
                }),
                new ArgumentException("Skip must be greater than or equal to 0."));

            await base.SDKExceptionResponseTestAsync(
               (ItemClient c) => c.GetSearchOptions(new ItemSearchOptionsRequest()
               {
                   Skip = 1,
                   Take = 0,
                   DelimitedDynamicAttributeValues = "1:1"
               }),
               new ArgumentOutOfRangeException("Take", 0, string.Format("{0} must be in range ({1} - {2}).", "Take", 1, 1000)));

            await base.SDKExceptionResponseTestAsync(
                (ItemClient c) => c.GetSearchOptions(new ItemSearchOptionsRequest()
                {
                    Take = 1,
                    MinWeight = 300,
                    MaxWeight = 400,
                    DelimitedDynamicAttributeValues = "1:1"
                }),
                new ArgumentNullException("WeightTypeId can not be null.")
            );

            await base.SDKExceptionResponseTestAsync(
              (ItemClient c) => c.GetSearchOptions(new ItemSearchOptionsRequest()
              {
                  Take = 1,
                  MinWidth = 300,
                  MinHeight = 300,
                  MinDepth = 400,
                  DelimitedDynamicAttributeValues = "1:1"
              }),
              new ArgumentNullException("DimensionTypeId can not be null."));

            await base.SDKExceptionResponseTestAsync(
              (ItemClient c) => c.GetSearchOptions(new ItemSearchOptionsRequest()
              {
                  Take = 1,
                  MinWidth = 300,
                  MaxWidth = 220,
                  DelimitedDynamicAttributeValues = "1:1"
              }),
              new ArgumentException(string.Format("{0} can not be greater than {1}.", "MinWidth", "MaxWidth")));
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (ItemClient c) => c.GetSearchOptions(sampleItemSearchOptionsRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("ItemClient"), TestCategory("GetSearchOptions"), TestCategory("HTTP.POST")]
        public async Task GetSearchOptionsDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ItemClient c) => c.GetSearchOptions(sampleItemSearchOptionsRequest));
        }

        #endregion
    }

}
