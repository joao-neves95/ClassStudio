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
                        outputSelector: 'input-selector',
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
                            method: 'GET',
                        });
                    });
                }
                static post(url, data) {
                    return __awaiter(this, void 0, void 0, function* () {
                        return yield fetch(url, {
                            method: 'POST',
                            body: data
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
                        return inputElem.nodeValue;
                    return null;
                }
                get inputSelectorElem() {
                    return document.getElementById(constants_1.Constants.Ids.Generator.inputSelector);
                }
                get inputSelectorValue() {
                    const inputSelectorElem = this.inputSelectorElem;
                    if (inputSelectorElem)
                        return inputSelectorElem.nodeValue;
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
                        return outputSelectorElem.nodeValue;
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
System.register("Generator/generator.services", ["httpClient"], function (exports_4, context_4) {
    "use strict";
    var httpClient_1, GeneratorService;
    var __moduleName = context_4 && context_4.id;
    return {
        setters: [
            function (httpClient_1_1) {
                httpClient_1 = httpClient_1_1;
            }
        ],
        execute: function () {
            GeneratorService = class GeneratorService {
                compile(input) {
                    return __awaiter(this, void 0, void 0, function* () {
                        if (!input)
                            null;
                        const res = yield httpClient_1.HttpClient.post('/generator/XMLStringToCSharp', {});
                        if (res.ok) {
                            return yield res.json();
                        }
                        else {
                            return res.statusText;
                        }
                    });
                }
            };
            exports_4("GeneratorService", GeneratorService);
        }
    };
});
System.register("Generator/generator.controller", ["Generator/generator.view", "Generator/generator.services"], function (exports_5, context_5) {
    "use strict";
    var generator_view_1, generator_services_1, GeneratorController;
    var __moduleName = context_5 && context_5.id;
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
                        if (outputElem)
                            yield this.service.compile(inputCode);
                        return false;
                    }));
                }
            };
            exports_5("GeneratorController", GeneratorController);
        }
    };
});
System.register("main", ["Generator/generator.controller"], function (exports_6, context_6) {
    "use strict";
    var generator_controller_1;
    var __moduleName = context_6 && context_6.id;
    function main() {
        console.log('Start.');
        new generator_controller_1.GeneratorController();
    }
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