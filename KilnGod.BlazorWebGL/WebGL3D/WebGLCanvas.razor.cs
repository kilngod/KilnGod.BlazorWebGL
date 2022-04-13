using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public partial class WebGLCanvas
    {
#nullable disable
        private IJSObjectReference asyncModule = null;

        private IJSInProcessObjectReference module = null;

        protected IJSRuntime _jsRuntime;

        protected IJSInProcessRuntime _jsInProcessRuntime = null;

        public event Action<WebGLCanvas> CanvasInitComplete = null;

#nullable enable

        [Parameter]
        public bool IsTransparent { get; set; } = false;

        [Parameter]
        public bool IsDesyncronized { get; set; } = false;




        [Parameter]
        public int Height { get; set; } = 600;

        [Parameter]
        public int Width { get; set; } = 800;

        [Parameter]
        public bool IsFullScreen { get; set; }

        //unique canvas id
        [Parameter]
        public string CanvasId { get; set; } = Guid.NewGuid().ToString();

        protected ElementReference _canvasRef;
        public ElementReference CanvasReference => this._canvasRef;


        public bool IsWebAssembley { get { return (_jsRuntime is IJSInProcessRuntime); } }


        [Inject]
        public IJSRuntime jsRuntime
        {
            get
            {
                return _jsRuntime;
            }
            set
            {
                _jsRuntime = value;

                if (IsWebAssembley)
                {
                    _jsInProcessRuntime = (IJSInProcessRuntime)value;

                }
            }
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {

                try
                {
                    if (IsWebAssembley)
                    {

                        module = await _jsInProcessRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/KilnGod.BlazorWebGL/WebGLCanvas.js");
                        //isWebassemblyClient, isTransparent, isPreserveDrawingBuffer, isDesynchronized
                        module.InvokeVoid("initializeWebGL", CanvasId, IsWebAssembley, IsTransparent, IsDesyncronized);
                    }
                    else
                    {
                        asyncModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/KilnGod.BlazorWebGL/WebGLCanvas.js");

                        await asyncModule.InvokeVoidAsync("initializeWebGL", CanvasId, IsWebAssembley, IsTransparent, IsDesyncronized);

                    }

                    if (CanvasInitComplete != null)
                        CanvasInitComplete(this);

                }
                catch (Exception ex)
                {
                    var crap = ex.Message;
                }

            }

        }

        public async ValueTask DisposeAsync()
        {
            if (asyncModule != null)
            {
                await asyncModule.DisposeAsync();
            }
            module?.Dispose();
        }

        public async ValueTask InjectScript(string scriptText)
        {
            if (module != null)
            {
                module.InvokeVoid("InjectScript", scriptText);
            }
            else
            {
                await asyncModule.InvokeVoidAsync("InjectScript", scriptText);
            }
        }

        /*
        public async ValueTask SetFunction(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                module.InvokeVoid(FunctionName, CanvasReference, args);
            }
            else
            {
                await asyncModule.InvokeVoidAsync(FunctionName, CanvasReference, args);
            }
        }


        public async ValueTask<T> GetFunction<T>(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                return module.Invoke<T>(FunctionName, CanvasReference, args);
            }
            else
            {
                return await asyncModule.InvokeAsync<T>(FunctionName, CanvasReference, args);
            }
        }

        */

        public async ValueTask SetValueWebGLContext(string ValueName, params object?[]? args)
        {
            if (module != null)
            {
                module.InvokeVoid("setValueWebGLContext", CanvasReference, ValueName, args);
            }
            else
            {
                await asyncModule.InvokeVoidAsync("setValueWebGLContext", CanvasReference, ValueName, args);
            }
        }


        public async ValueTask<T> GetValueWebGLContext<T>(string ValueName, params object?[]? args)
        {
            if (module != null)
            {
                return module.Invoke<T>("getValueWebGLContext", CanvasReference, ValueName, args);
            }
            else
            {
                return await asyncModule.InvokeAsync<T>("getValueWebGLContext", CanvasReference, ValueName, args);
            }
        }



        public async ValueTask SetFunctionWebGLContext(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                module.InvokeVoid("setFunctionWebGLContext", CanvasReference, FunctionName, args);
            }
            else
            {
                await asyncModule.InvokeVoidAsync("setFunctionWebGLContext", CanvasReference, FunctionName, args);
            }
        }


        public async ValueTask<T> GetFunctionWebGLContext<T>(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                return module.Invoke<T>("getFunctionWebGLContext", CanvasReference, FunctionName, args);
            }
            else
            {
                return await asyncModule.InvokeAsync<T>("getFunctionWebGLContext", CanvasReference, FunctionName, args);
            }
        }


        public async ValueTask SetFunctionWebGLBasis(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                module.InvokeVoid("setFunctionWebGLBasis", CanvasReference, FunctionName, args);
            }
            else
            {
                await asyncModule.InvokeVoidAsync("setFunctionWebGLBasis", CanvasReference, FunctionName, args);
            }
        }


        public async ValueTask<T> GetFunctionWebGLBasis<T>(string FunctionName, params object?[]? args)
        {
            if (module != null)
            {
                return module.Invoke<T>("getFunctionWebGLBasis", CanvasReference, FunctionName, args);
            }
            else
            {
                return await asyncModule.InvokeAsync<T>("getFunctionWebGLBasis", CanvasReference, FunctionName, args);
            }
        }



    }
}
