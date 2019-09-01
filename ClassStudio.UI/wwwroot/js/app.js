/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
System.register("constants", [], function (exports_1, context_1) {
    "use strict";
    var Constants;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            exports_1("Constants", Constants = Object.freeze({
                Ids: {
                    Generator: {
                        inputSelector: 'input-selector',
                        outputSelector: 'output-selector',
                        compileBtn: 'compile-btn'
                    }
                }
            }));
        }
    };
});
System.register("httpClient", [], function (exports_2, context_2) {
    "use strict";
    var HttpClient;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [],
        execute: function () {
            HttpClient = class HttpClient {
                static get(url) {
                    return __awaiter(this, void 0, void 0, function* () {
                        return yield fetch(url, {
                            headers: {
                                'Accept': 'application/json, text/plain',
                            },
                            method: 'GET'
                        });
                    });
                }
                static post(url, data) {
                    return __awaiter(this, void 0, void 0, function* () {
                        return yield fetch(url, {
                            headers: {
                                'Accept': 'application/json, text/plain',
                                'Content-Type': 'application/json;charset=UTF-8'
                            },
                            method: 'POST',
                            body: JSON.stringify(data)
                        });
                    });
                }
            };
            exports_2("HttpClient", HttpClient);
        }
    };
});
System.register("Generator/generator.view", ["constants"], function (exports_3, context_3) {
    "use strict";
    var constants_1, GeneratorView;
    var __moduleName = context_3 && context_3.id;
    return {
        setters: [
            function (constants_1_1) {
                constants_1 = constants_1_1;
            }
        ],
        execute: function () {
            GeneratorView = class GeneratorView {
                get inputElem() {
                    return document.getElementById('input-code');
                }
                get inputElemValue() {
                    const inputElem = this.inputElem;
                    if (inputElem)
                        return inputElem.value;
                    return null;
                }
                get inputSelectorElem() {
                    return document.getElementById(constants_1.Constants.Ids.Generator.inputSelector);
                }
                get inputSelectorValue() {
                    const inputSelectorElem = this.inputSelectorElem;
                    if (inputSelectorElem)
                        return inputSelectorElem.selectedOptions[0].value;
                    return null;
                }
                get outputElem() {
                    return document.getElementById('output-textarea');
                }
                get outputElemValue() {
                    const outpuElem = this.outputElem;
                    if (outpuElem)
                        return outpuElem.nodeValue;
                    return null;
                }
                get outputSelectorElem() {
                    return document.getElementById(constants_1.Constants.Ids.Generator.outputSelector);
                }
                get outputSelectorValue() {
                    const outputSelectorElem = this.outputSelectorElem;
                    if (outputSelectorElem)
                        return outputSelectorElem.selectedOptions[0].value;
                    return null;
                }
                get compileBtnElem() {
                    return document.getElementById(constants_1.Constants.Ids.Generator.compileBtn);
                }
            };
            exports_3("GeneratorView", GeneratorView);
        }
    };
});
System.register("Enums/LangEnum", [], function (exports_4, context_4) {
    "use strict";
    var LangEnum;
    var __moduleName = context_4 && context_4.id;
    return {
        setters: [],
        execute: function () {
            (function (LangEnum) {
                LangEnum[LangEnum["XML"] = 1] = "XML";
                LangEnum[LangEnum["CSharp"] = 2] = "CSharp";
                LangEnum[LangEnum["TypeScript"] = 3] = "TypeScript";
                LangEnum[LangEnum["JavaScript"] = 4] = "JavaScript";
                LangEnum[LangEnum["JSON"] = 5] = "JSON";
            })(LangEnum || (LangEnum = {}));
            exports_4("LangEnum", LangEnum);
            ;
        }
    };
});
System.register("Generator/generator.services", ["httpClient", "Enums/LangEnum"], function (exports_5, context_5) {
    "use strict";
    var httpClient_1, LangEnum_1, GeneratorService;
    var __moduleName = context_5 && context_5.id;
    return {
        setters: [
            function (httpClient_1_1) {
                httpClient_1 = httpClient_1_1;
            },
            function (LangEnum_1_1) {
                LangEnum_1 = LangEnum_1_1;
            }
        ],
        execute: function () {
            GeneratorService = class GeneratorService {
                get baseApiPath() {
                    return 'api/generator/';
                }
                ;
                compile(inputCode, inputType, outputType) {
                    return __awaiter(this, void 0, void 0, function* () {
                        if (!inputCode || !inputType || !outputType)
                            return "[INPUT NOT VALID]";
                        let res;
                        if (inputType == LangEnum_1.LangEnum.XML && outputType == LangEnum_1.LangEnum.CSharp) {
                            res = yield this.postInputToServer('XMLStringToCSharp', inputCode);
                        }
                        else if (inputType == LangEnum_1.LangEnum.CSharp && outputType == LangEnum_1.LangEnum.TypeScript) {
                            res = yield this.postInputToServer('CSharpToTypescript', inputCode);
                        }
                        else {
                            return "[NOT IMPLEMENTED]";
                        }
                        if (res.ok)
                            return yield res.json();
                        return JSON.stringify(yield res.json());
                    });
                }
                postInputToServer(endpoint, input) {
                    return __awaiter(this, void 0, void 0, function* () {
                        return yield httpClient_1.HttpClient.post(this.baseApiPath + endpoint, { Input: input });
                    });
                }
            };
            exports_5("GeneratorService", GeneratorService);
        }
    };
});
System.register("Generator/generator.controller", ["Generator/generator.view", "Generator/generator.services"], function (exports_6, context_6) {
    "use strict";
    var generator_view_1, generator_services_1, GeneratorController;
    var __moduleName = context_6 && context_6.id;
    return {
        setters: [
            function (generator_view_1_1) {
                generator_view_1 = generator_view_1_1;
            },
            function (generator_services_1_1) {
                generator_services_1 = generator_services_1_1;
            }
        ],
        execute: function () {
            GeneratorController = class GeneratorController {
                constructor() {
                    this.view = new generator_view_1.GeneratorView();
                    this.service = new generator_services_1.GeneratorService();
                    this.addListeners();
                }
                addListeners() {
                    const compileBtnElem = this.view.compileBtnElem;
                    if (!compileBtnElem)
                        return;
                    compileBtnElem.addEventListener('click', (e) => __awaiter(this, void 0, void 0, function* () {
                        const inputType = this.view.inputSelectorValue;
                        const outputType = this.view.outputSelectorValue;
                        const inputCode = this.view.inputElemValue;
                        const outputElem = this.view.outputElem;
                        if (!inputCode || !outputElem)
                            return false;
                        outputElem.value = yield this.service.compile(inputCode, Number(inputType), Number(outputType));
                    }));
                }
            };
            exports_6("GeneratorController", GeneratorController);
        }
    };
});
System.register("main", ["Generator/generator.controller"], function (exports_7, context_7) {
    "use strict";
    var generator_controller_1;
    var __moduleName = context_7 && context_7.id;
    function main() {
        new generator_controller_1.GeneratorController();
    }
    exports_7("main", main);
    return {
        setters: [
            function (generator_controller_1_1) {
                generator_controller_1 = generator_controller_1_1;
            }
        ],
        execute: function () {
            main();
        }
    };
});
//# sourceMappingURL=app.js.map