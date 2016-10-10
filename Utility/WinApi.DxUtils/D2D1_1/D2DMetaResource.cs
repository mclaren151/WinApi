﻿using System;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using WinApi.DxUtils.Core;
using Device = SharpDX.Direct2D1.Device;
using Factory = SharpDX.Direct2D1.Factory;
using Factory1 = SharpDX.Direct2D1.Factory1;

namespace WinApi.DxUtils.D2D1_1
{
    public class D2DMetaResource : ID2D1_1MetaResourceImpl
    {
        private DeviceContext m_context;
        private CreationProperties m_creationProperties;
        private Device m_device;
        private IDxgi1Container m_dxgiContainer;
        private Factory1 m_factory;
        private bool m_isDisposed;

        public D2DMetaResource(CreationProperties props)
        {
            m_creationProperties = props;
        }

        public RenderTarget RenderTarget => Context;
        public Factory Factory => Factory1;

        public Device Device
        {
            get { return m_device; }
            private set { m_device = value; }
        }

        public DeviceContext Context
        {
            get { return m_context; }
            private set { m_context = value; }
        }

        public Factory1 Factory1
        {
            get { return m_factory; }
            private set { m_factory = value; }
        }

        public void Dispose()
        {
            m_isDisposed = true;
            GC.SuppressFinalize(this);
            Destroy();
        }

        public void ConnectToDxgi()
        {
            CheckDisposed();
            ConnectContextToDxgiSurface();
        }

        public void DisconnectFromDxgi()
        {
            DisconnectContextFromDxgiSurface();
        }

        public void Initialize(IDxgi1Container dxgiContainer, bool autoLink = false)
        {
            CheckDisposed();
            m_dxgiContainer = dxgiContainer;
            if (autoLink) dxgiContainer.AddLinkedResource(this);
        }

        public void Destroy()
        {
            m_dxgiContainer?.RemoveLinkedResource(this);
            DisconnectContextFromDxgiSurface();
            DisposableHelpers.DisposeAndSetNull(ref m_context);
            DisposableHelpers.DisposeAndSetNull(ref m_device);
            DisposableHelpers.DisposeAndSetNull(ref m_factory);
        }

        private void CreateFactory()
        {
            var props = m_creationProperties;
            Factory1 = new Factory1((FactoryType) props.ThreadingMode, props.DebugLevel);
        }

        private void EnsureFactory()
        {
            if (Factory1 == null)
                CreateFactory();
        }

        private void CreateDevice()
        {
            EnsureFactory();
            Device = new Device(m_dxgiContainer.DxgiDevice, m_creationProperties);
        }

        private void EnsureDevice()
        {
            if (Device == null)
                CreateDevice();
        }

        private void CreateContext()
        {
            EnsureDevice();
            Context = new DeviceContext(Device, m_creationProperties.Options);
        }

        private void EnsureContext()
        {
            if (Context == null)
                CreateContext();
        }

        private void ConnectContextToDxgiSurface()
        {
            EnsureContext();
            using (var surface = m_dxgiContainer.SwapChain.GetBackBuffer<Surface>(0))
            {
                using (var bitmap = new Bitmap1(Context, surface))
                    Context.Target = bitmap;
            }
        }

        private void DisconnectContextFromDxgiSurface()
        {
            var currentTarget = Context?.Target;
            if (currentTarget == null) return;
            currentTarget.Dispose();
            Context.Target = null;
        }

        private void CheckDisposed()
        {
            if (m_isDisposed) throw new ObjectDisposedException(nameof(D2DMetaResource));
        }

        ~D2DMetaResource()
        {
            Dispose();
        }
    }
}