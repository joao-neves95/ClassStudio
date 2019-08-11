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
                get inputSelectorElem() {
                    return document.getElementById(constants_1.Constants.Ids.Generator.inputSelector);
                }
                get inputSelectorValue() {
                    const inputSelectorElem = this.inputSelectorElem;
                    if (inputSelectorElem)
                        return inputSelectorElem.nodeValue;
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
System.register("Generator/generator.controller", ["Generator/generator.view"], function (exports_4, context_4) {
    "use strict";
    var generator_view_1, GeneratorController;
    var __moduleName = context_4 && context_4.id;
    return {
        setters: [
            function (generator_view_1_1) {
                generator_view_1 = generator_view_1_1;
            }
        ],
        execute: function () {
            GeneratorController = class GeneratorController {
                constructor() {
                    this.view = new generator_view_1.GeneratorView();
                    this.addListeners();
                }
                addListeners() {
                    const compileBtnElem = this.view.compileBtnElem;
                    if (!compileBtnElem)
                        return;
                    compileBtnElem.addEventListener('click', (e) => {
                        const inputType = this.view.inputSelectorValue;
                        const outputType = this.view.outputSelectorValue;
                    });
                }
            };
            exports_4("GeneratorController", GeneratorController);
        }
    };
});
System.register("main", ["Generator/generator.controller"], function (exports_5, context_5) {
    "use strict";
    var generator_controller_1, generatorController;
    var __moduleName = context_5 && context_5.id;
    return {
        setters: [
            function (generator_controller_1_1) {
                generator_controller_1 = generator_controller_1_1;
            }
        ],
        execute: function () {
            generatorController = new generator_controller_1.GeneratorController();
        }
    };
});
System.register("Generator/generator.services", ["httpClient"], function (exports_6, context_6) {
    "use strict";
    var httpClient_1, GeneratorView;
    var __moduleName = context_6 && context_6.id;
    return {
        setters: [
            function (httpClient_1_1) {
                httpClient_1 = httpClient_1_1;
            }
        ],
        execute: function () {
            GeneratorView = class GeneratorView {
                compile() {
                    return __awaiter(this, void 0, void 0, function* () {
                        const res = yield httpClient_1.HttpClient.post('', {});
                        if (res.ok)
                            return yield res.json();
                    });
                }
            };
            exports_6("GeneratorView", GeneratorView);
        }
    };
});
//# sourceMappingURL=app.js.map